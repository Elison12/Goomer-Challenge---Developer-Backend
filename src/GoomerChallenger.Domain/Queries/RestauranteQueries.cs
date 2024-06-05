using System.Linq.Expressions;
using GoomerChallenger.Domain.Interfaces.Queries;
using GoomerChallenger.Domain.Models;

namespace GoomerChallenger.Domain.Queries
{
    public class RestauranteQueries : IRestauranteQueries
    {
        public Expression<Func<Restaurante, bool>> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Expression<Func<Restaurante, bool>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Expression<Func<Restaurante, bool>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
