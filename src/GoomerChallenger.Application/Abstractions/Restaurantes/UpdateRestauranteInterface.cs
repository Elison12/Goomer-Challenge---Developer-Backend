using GoomerChallenger.Application.UserCases.Restaurantes.Request;
using GoomerChallenger.Domain.Interfaces.Abstractions;

namespace GoomerChallenger.Application.Abstractions.Restaurantes
{
    public interface UpdateRestauranteInterface
    {
        Task<IResponse> Handle(UpdateRestauranteRequest request, CancellationToken cancellationToken);
    }
}
