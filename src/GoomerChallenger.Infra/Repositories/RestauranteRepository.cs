using GoomerChallenger.Domain.Models;
using GoomerChallenger.Infra.Data.Context;
using GoomerChallenger.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GoomerChallenger.Infra.Repositories
{
    public sealed class RestauranteRepository : BaseRepository<Restaurante>, IRestauranteRepository
    {
        private readonly GoomerContext _goomerContext;
        private readonly IBaseRepository<Restaurante> _baseRepository;
        public RestauranteRepository(IBaseRepository<Restaurante> baseRepository, GoomerContext context) : base(context)
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
