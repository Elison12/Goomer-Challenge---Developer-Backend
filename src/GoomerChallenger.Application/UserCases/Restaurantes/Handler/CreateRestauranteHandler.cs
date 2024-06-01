
using System.Net;
using GoomerChallenger.Application.Abstractions.Response;
using GoomerChallenger.Application.Abstractions.Restaurantes;
using GoomerChallenger.Application.UserCases.Restaurantes.Request;
using GoomerChallenger.Application.UserCases.Restaurantes.Response;
using GoomerChallenger.Domain.Interfaces.Abstractions;
using GoomerChallenger.Domain.Interfaces.UnitOfWork;
using GoomerChallenger.Domain.Models;
using GoomerChallenger.Infra.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace GoomerChallenger.Application
    .UserCases.Restaurantes.Handler
{
    public class CreateRestauranteHandler : ICreateRestaurante
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IRestauranteRepository _IRestauranteRepository;
        private readonly IWebHostEnvironment _env;
        public CreateRestauranteHandler(IRestauranteRepository restauranteRepository, IUnitOfWork iUnitOfWork, IWebHostEnvironment env)
        {
            _IUnitOfWork = iUnitOfWork;
            _IRestauranteRepository = restauranteRepository;
            _env = env;
        }

        public async Task<IResponse> Handle(CreateRestauranteRequest request)
        {
            #region validações

            var result = request.Validar();

            if (!result.IsValid)
                return new InvalidRequest(
                       statuscode: HttpStatusCode.BadRequest,
                       message: "Requisição invalida. Verifique os dados informados",
                       errors: result.Errors.ToDictionary(error => error.PropertyName, error => error.ErrorMessage)
                    );

            #endregion
            try
            {
                #region Verificações
                var restauranteSearch = await _IRestauranteRepository.SearchByName(request.Nome);
                if (restauranteSearch is null)
                {
                    return new AlreadyExists(statuscode: HttpStatusCode.Conflict, message: "Já existe um restaurante com esse nome.");
                }

                var pathimage = await SaveImagem(request.Foto);
                if (pathimage is null)
                {
                    return new UnsupportedFile(statuscode: HttpStatusCode.Conflict, message: "Não foi possivel salvar um resturante com essa imagem.");
                }
                #endregion

                return await AddRestaurante(request.Nome, request.Endereco, pathimage);
            }
            catch (Exception)
            {
                _IUnitOfWork.RollBack();
                throw;
            }
            finally
            {
                _IUnitOfWork.Dispose();
            }
        }


        private async Task<IResponse> AddRestaurante(string nome, string endereco, string caminhoImagem)
        {
            var newRestaurante = new Restaurante(
                nome: nome,
                endereco: endereco,
                caminhoFoto: caminhoImagem
            );

            if (!newRestaurante.Isvalid)
                return new DomainNotification(StatusCode: HttpStatusCode.BadRequest,
                                                   Errors: newRestaurante.Errors);
            _IUnitOfWork.BeginTransaction();

            await _IRestauranteRepository.CreateAsync(newRestaurante);


            return new CreatedSuccessfully(statuscode: HttpStatusCode.Created,
                                          message: "Um novo restaurante foi criado !"
                                          );
        }
        public async Task<String> SaveImagem(IFormFile imagemRecebida)
        {
            var caminhoPasta = Path.Combine(_env.WebRootPath, "imagens");
            if (!Directory.Exists(caminhoPasta))
            {
                Directory.CreateDirectory(caminhoPasta);
            }

            var nomeArquivo = Guid.NewGuid() + Path.GetExtension(imagemRecebida.FileName);
            var caminhoArquivo = Path.Combine(caminhoPasta, nomeArquivo);

            using (var fileStream = new FileStream(caminhoArquivo, FileMode.Create))
            {
                await imagemRecebida.CopyToAsync(fileStream);
            }

            return Path.Combine("imagens", nomeArquivo);
        }



    }
}
