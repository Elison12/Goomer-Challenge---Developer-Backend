using System.Linq.Expressions;
using GoomerChallenger.Domain.Models;

namespace GoomerChallenger.Domain.Interfaces.Queries
{
    public interface IRestauranteQueries
    {
        Expression<Func<Restaurante, bool>> GetByIdAsync(int id);
        Expression<Func<Restaurante, bool>> GetByEmailAsync(string email);
        Expression<Func<Restaurante, bool>> GetByNameAsync(string name);
    }
}
