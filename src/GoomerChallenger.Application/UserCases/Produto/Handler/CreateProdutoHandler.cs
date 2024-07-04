using System.Net;
using GoomerChallenger.Application.Abstractions.Produtos;
using GoomerChallenger.Application.Abstractions.Response;
using GoomerChallenger.Application.UserCases.Produtos.Request;
using GoomerChallenger.Application.UserCases.Produtos.Response;
using GoomerChallenger.Domain.Interfaces.Abstractions;
using GoomerChallenger.Domain.Interfaces.ProdutoRepository;
using GoomerChallenger.Domain.Interfaces.UnitOfWork;
using GoomerChallenger.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace GoomerChallenger.Application.UserCases.Produtos.Handler
{
    public sealed class CreateProdutoHandler : CreateProdutoInterface
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IProdutoRepository _ProdutoRepository;
        private readonly IWebHostEnvironment _env;

        public CreateProdutoHandler(IUnitOfWork unitOfWork, IProdutoRepository produtoRepository, IWebHostEnvironment env)
        {
            _UnitOfWork = unitOfWork;
            _ProdutoRepository = produtoRepository;
            _env = env;
        }

        public async Task<IResponse> Handle(CreateProdutoRequest request, CancellationToken cancellationToken)
        {
            #region Validações
            var result = request.Validar();

            if (!result.IsValid)
            {
                return new InvalidRequest(
                        statuscode: HttpStatusCode.BadRequest,
                       message: "Requisição invalida. Verifique os dados informados",
                       errors: result.Errors.ToDictionary(error => error.PropertyName, error => error.ErrorMessage)
                );
            }
            #endregion
            string pathImage = null;
            try
            {
                #region verificações
                var produtoSearch = await _ProdutoRepository.SearchByName(request.Nome);
                
                if (produtoSearch is not null)
                {
                    return new AlreadyExists(statuscode: HttpStatusCode.Conflict, message: "Já existe um produto com esse nome.");
                }


                pathImage = await SaveImagem(request.CaminhoFoto);
                if (pathImage is null)
                {
                    return new UnsupportedFile(statuscode: HttpStatusCode.Conflict, message: "Não foi possivel salvar um resturante com essa imagem.");
                }
                #endregion
                return await AddProduto(request.Nome, request.Codigo, request.Valor,
                                        request.Categoria, request.DtValidade, request.DtAquisicao,
                                        pathImage, request.Departamento, request.Lote, cancellationToken);
            }
            catch (Exception)
            {

                _UnitOfWork.RollBack();

                // Deleta a imagem caso ocorra um erro
                if (pathImage != null)
                {
                    DeleteImagem(pathImage);
                }

                throw;
            }
            finally
            {
                _UnitOfWork.Dispose();
            }
        }

        private async Task<IResponse> AddProduto(string nome, string codigo, float valor, string categoria, string DtValidade, string DtAquisicao, string pathimage, string departamento, int Lote, CancellationToken cancellationToken)
        {

            var produto = new Produto(
                nome: nome,
                codigo: codigo,
                valor: valor,
                categoria: categoria,
                dtValidade: DtValidade,
                dtAquisicao: DtAquisicao,
                caminhoFoto: pathimage,
                departamento: departamento,
                lote: Lote
            );

            if (!produto.Isvalid)
            {
                return new DomainNotification(StatusCode: HttpStatusCode.BadRequest,
                                                  Errors: produto.Errors);
            }
            _UnitOfWork.BeginTransaction();

            await _ProdutoRepository.AddAsync(produto);

            await _UnitOfWork.Commit(cancellationToken);

            return new CreatedSuccessfully(statuscode: HttpStatusCode.Created,
                                          message: "Um novo produto foi criado !"
                                          );
        }

        public async Task<string> SaveImagem(IFormFile imagemRecebida)
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

        private void DeleteImagem(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
