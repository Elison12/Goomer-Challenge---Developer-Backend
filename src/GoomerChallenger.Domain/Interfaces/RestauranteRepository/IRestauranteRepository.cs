using GoomerChallenger.Domain.Models;

namespace GoomerChallenger.Domain.Interfaces.RestauranteRepository
{
    public interface IRestauranteRepository
    {
        Task AddAsync(Restaurante restaurante);
        Task<Restaurante> SearchByName(string name);
        Task<Restaurante> GetByIdAsync(int id);
        Task<Boolean> RemoveAsync(Restaurante request);
    }
}
