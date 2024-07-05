using System.Net;
using GoomerChallenger.Application.Abstractions.Produtos;
using GoomerChallenger.Application.UserCases.Produtos.Request;
using GoomerChallenger.Application.UserCases.Produtos.Response;
using GoomerChallenger.Domain.Interfaces.Abstractions;
using GoomerChallenger.Domain.Interfaces.ProdutoRepository;
using GoomerChallenger.Domain.Interfaces.UnitOfWork;
using GoomerChallenger.Domain.Models;
using GoomerChallenger.Infra.Repositories;

namespace GoomerChallenger.Application.UserCases.Produtos.Handler
{
    public class DeleteProdutoHandler : DeleteProdutoInterface
    {

        private readonly IProdutoRepository _produtoRespository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProdutoHandler(IProdutoRepository produtoRespository, IUnitOfWork unitOFWork)
        {
            _produtoRespository = produtoRespository;
            _unitOfWork = unitOFWork;
        }
        public async Task<IResponse> Handler(DeleteProdutoRequest request, CancellationToken cancellationToken)
        {
            #region validações
            var result = request.Validar();

            if (!result.IsValid)
            {
                return new InvalidRequest(statuscode: HttpStatusCode.BadRequest,
                                             message: "Requisição inválida. Por favor, valide os dados informados.",
                                             errors: result.Errors.ToDictionary(error => error.PropertyName, error => error.ErrorMessage));
            }
            #endregion

            try
            {
                #region buscar produto
                var search = await _produtoRespository.GetByIdAsync(request.idProdutoResquest);

                if (search is null)
                    return new NotFoundProduto(statusCode: HttpStatusCode.NotFound, message: "Restaurante não encontrado para o id informado");
                #endregion

                return await DeleteProduto(search, cancellationToken);
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

        private async Task<IResponse> DeleteProduto(Produto produto, CancellationToken cancellationToken)
        {
            _unitOfWork.BeginTransaction();
            await _produtoRespository.DeleteAsync(produto);

            await _unitOfWork.Commit(cancellationToken);
            return new DeletedSuccessfully(statuscode: HttpStatusCode.OK,
                             message: $"produto {produto.Nome} excluído com sucesso.");
        }
    }
}
