

using GoomerChallenger.Domain.Interfaces.BaseRepository;
using GoomerChallenger.Domain.Interfaces.ProdutoRepository;
using GoomerChallenger.Domain.Models;
using GoomerChallenger.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GoomerChallenger.Infra.Repositories
{
    public sealed class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly GoomerContext _goomerContext;
        //private readonly IBaseRepository<Produto> _baseRepository;

        public ProdutoRepository(GoomerContext goomerContext) : base(goomerContext)
        {
            _goomerContext = goomerContext;
        }

        public async Task<Produto> SearchByName(string name)
        {
            var result = await _goomerContext.Produto
                                .FirstOrDefaultAsync(x => x.Nome == name);
            if (result is null)
            {
                return null;
            }
            return result;
        }

        public async Task<Produto> GetByIdAsync(int id)
        {
            var result = await _goomerContext.Produto
                                               .FirstOrDefaultAsync(x => x.IdProduto == id);
            if (result is null)
                return null;

            return result;
        }

    }
}
