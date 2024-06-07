using GoomerChallenger.Application.UserCases.Restaurantes.Request;
using GoomerChallenger.Domain.Interfaces.Abstractions;

namespace GoomerChallenger.Application.Abstractions.Restaurantes
{
    public interface DeleteRestauranteInterface
    {
        Task<IResponse> Handler(DeleteRestauranteRequest request, CancellationToken cancellationToken);
    }
}
