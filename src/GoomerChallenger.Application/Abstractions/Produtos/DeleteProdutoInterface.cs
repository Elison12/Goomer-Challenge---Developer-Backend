using GoomerChallenger.Application.UserCases.Produtos.Request;
using GoomerChallenger.Domain.Interfaces.Abstractions;

namespace GoomerChallenger.Application.Abstractions.Produtos
{
    public interface DeleteProdutoInterface
    {
        Task<IResponse> Handler(DeleteProdutoRequest request, CancellationToken cancellationToken);
    }
}
