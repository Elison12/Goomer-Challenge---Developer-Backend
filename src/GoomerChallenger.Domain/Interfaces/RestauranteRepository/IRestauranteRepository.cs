using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoomerChallenger.Domain.Models;

namespace GoomerChallenger.Domain.Interfaces.RestauranteRepository
{
    public interface IRestauranteRepository
    {
        Task AddAsync(Restaurante restaurante);
        Task<Restaurante> SearchByName (string name);
    }
}
