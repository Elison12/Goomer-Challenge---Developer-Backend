using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoomerChallenger.Domain.Models;

namespace GoomerChallenger.Infra.Interfaces
{
    public interface IRestauranteRepository : IBaseRepository<Restaurante>
    {
        Task <Restaurante> SearchByName(String  name);
        Task AddAsync(Restaurante restaurante);
    }
}
