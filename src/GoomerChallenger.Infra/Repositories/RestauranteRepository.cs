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


    }
}
