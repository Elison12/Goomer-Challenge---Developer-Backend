using GoomerChallenger.Domain.Interfaces.BaseRepository;
using GoomerChallenger.Domain.Models;

namespace GoomerChallenger.Domain.Interfaces.ProdutoRepository
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        Task<Produto> SearchByName(string name);
        Task<Produto> GetByIdAsync(int id);
    }
}
