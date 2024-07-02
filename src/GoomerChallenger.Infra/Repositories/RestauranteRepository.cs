using GoomerChallenger.Domain.Interfaces.BaseRepository;
using GoomerChallenger.Domain.Interfaces.RestauranteRepository;
using GoomerChallenger.Domain.Models;
using GoomerChallenger.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GoomerChallenger.Infra.Repositories
{
    public sealed class RestauranteRepository : IRestauranteRepository
    {
        private readonly GoomerContext _goomerContext;
        private readonly IBaseRepository<Restaurante> _baseRepository;
        public RestauranteRepository(IBaseRepository<Restaurante> baseRepository, GoomerContext context)
        {
            _baseRepository = baseRepository;
            _goomerContext = context;
        }

        public async Task<Restaurante> SearchByName(string name)
        {
            var result = await _goomerContext.Restaurante
                                .FirstOrDefaultAsync(x => x.Nome == name);
            if (result is null)
            {
                return null;
            }
            return result;
        }
        public Task AddAsync(Restaurante restaurante)
            => _baseRepository.AddAsync(restaurante);

        public async Task<Restaurante> GetByIdAsync(int id)
        {
            var result = await _goomerContext.Restaurante
                                               .FirstOrDefaultAsync(x => x.idRestaurante == id);
            if (result is null)
                return null;
            return result;
        }
        public async Task<bool> RemoveAsync(Restaurante request)
        {
            var deleted = await _goomerContext
                    .Restaurante
                    .Where(x => x.idRestaurante == request.idRestaurante)
                    .ExecuteDeleteAsync();

            return deleted != 0;
        }

        public async Task<bool> UpdateRestauranteAsync(Restaurante restaurante)
        {
            var updated = _goomerContext.Entry(restaurante).State = EntityState.Modified;
            await _goomerContext.SaveChangesAsync();

            return updated != 0;
        }
    }
}
