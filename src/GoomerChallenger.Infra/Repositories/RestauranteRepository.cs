using GoomerChallenger.Domain.Models;
using GoomerChallenger.Infra.Data.Context;
using GoomerChallenger.Infra.Interfaces;

namespace GoomerChallenger.Infra.Repositories
{
    public sealed class RestauranteRepository : BaseRepository<Restaurante>, IRestauranteRepository
    {
        private readonly GoomerContext _goomerContext;
        private readonly IBaseRepository<Restaurante> _baseRepository;
        public RestauranteRepository(IBaseRepository<Restaurante> baseRepository, GoomerContext context) : base(context)
        {
            _goomerContext = context;
        }
    }
}
