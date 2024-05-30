using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoomerChallenger.Application.UserCases.Restaurante.Request;
using GoomerChallenger.Domain.Interfaces.Abstractions;

namespace GoomerChallenger.Application.Interfaces.Restaurante
{
    public interface ICreateRestaurante
    {
        Task<IResponse> Handle(CreateRestauranteRequest request);
    }
}
