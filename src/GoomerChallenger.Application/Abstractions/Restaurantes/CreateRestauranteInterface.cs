using GoomerChallenger.Application.UserCases.Restaurantes.Request;
using GoomerChallenger.Domain.Interfaces.Abstractions;
using Microsoft.AspNetCore.Http;

namespace GoomerChallenger.Application.Abstractions.Restaurantes;

public interface ICreateRestaurante
{
    Task<IResponse> Handle(CreateRestauranteRequest request, CancellationToken cancellationToken);
    Task<String> SaveImagem(IFormFile imagemRecebida);
}
