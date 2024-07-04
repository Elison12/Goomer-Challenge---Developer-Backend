using GoomerChallenger.Application.UserCases.Produtos.Request;
using GoomerChallenger.Domain.Interfaces.Abstractions;
using Microsoft.AspNetCore.Http;

namespace GoomerChallenger.Application.Abstractions.Produtos
{
    public interface CreateProdutoInterface
    {
        Task<IResponse> Handle(CreateProdutoRequest request, CancellationToken cancellationToken);
        Task<String> SaveImagem(IFormFile imagemRecebida);
    }
}
