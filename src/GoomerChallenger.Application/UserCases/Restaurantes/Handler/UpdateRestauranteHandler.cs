using System.Net;
using AutoMapper;
using GoomerChallenger.Application.Abstractions.Restaurantes;
using GoomerChallenger.Application.UserCases.Restaurantes.Request;
using GoomerChallenger.Application.UserCases.Restaurantes.Response;
using GoomerChallenger.Domain.Interfaces.Abstractions;
using GoomerChallenger.Domain.Interfaces.RestauranteRepository;
using GoomerChallenger.Domain.Interfaces.UnitOfWork;
using GoomerChallenger.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace GoomerChallenger.Application.UserCases.Restaurantes.Handler
{
    public class UpdateRestauranteHandler : UpdateRestauranteInterface
    {
        private readonly IRestauranteRepository _RestauranteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        public UpdateRestauranteHandler(IRestauranteRepository restauranteRepository, IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _RestauranteRepository = restauranteRepository;
            _unitOfWork = unitOfWork;
            _env = env;
        }

        public async Task<IResponse> Handle(UpdateRestauranteRequest request, CancellationToken cancellationToken)
        {
            #region Validaçoes

            var result = request.Validar();

            if (!result.IsValid)
                return new InvalidRequest(
                       statuscode: HttpStatusCode.BadRequest,
                       message: "Requisição invalida. Verifique os dados informados",
                       errors: result.Errors.ToDictionary(error => error.PropertyName, error => error.ErrorMessage)
                );

            #endregion
            string pathimage = null;
            try
            {
                #region buscar Restaurante
                var restauranteSearch = await _RestauranteRepository.GetByIdAsync(request.idRestauranteBusca);

                if (restauranteSearch is null)
                {
                    return new NotFoundRestaurante(statusCode: HttpStatusCode.NotFound, message: "Restaurante não encontrado para o id informado");
                }
                #endregion

                #region Inserindo Imagem

                pathimage = await SaveImagem(request.Foto);
                if (pathimage is null)
                {
                    return new UnsupportedFile(statuscode: HttpStatusCode.Conflict, message: "Não foi possivel salvar um resturante com essa imagem.");
                }
                #endregion


                restauranteSearch.Nome = request.Nome;
                restauranteSearch.Endereco = request.Endereco;
                restauranteSearch.CaminhoFoto = pathimage;
                restauranteSearch.Telefone = request.Telefone;
                restauranteSearch.Gerente = request.Gerente;
                restauranteSearch.NumFuncionarios = request.NumFuncionarios;

                return await UpdateRestaurante(restauranteSearch, cancellationToken);
            }
            catch (Exception)
            {
                _unitOfWork.RollBack();
                throw;
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }

        private async Task<IResponse> UpdateRestaurante(Restaurante restauranteSearch, CancellationToken cancellationToken)
        {

            _unitOfWork.BeginTransaction();

            var updated = await _RestauranteRepository.UpdateRestauranteAsync(restauranteSearch);
            if (updated == false)
                return new UpdateRestauranteError(statuscode: HttpStatusCode.InternalServerError,
                                           message: "Houve uma falha na atualização dos dados do restaurante.");

            await _unitOfWork.Commit(cancellationToken);

            return new UpdatedSuccessfully(statuscode: HttpStatusCode.OK,
                                         message: $"Dados do restaurante {restauranteSearch.Id} atualizados com sucesso!");
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
