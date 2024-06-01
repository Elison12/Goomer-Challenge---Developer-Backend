using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoomerChallenger.Application.UserCases.Restaurantes.Request;
using GoomerChallenger.Domain.Interfaces.Abstractions;
using Microsoft.AspNetCore.Http;

namespace GoomerChallenger.Application.Abstractions.Restaurantes;

public interface ICreateRestaurante
{
    Task<IResponse> Handle(CreateRestauranteRequest request);
    Task<String> SaveImagem(IFormFile imagemRecebida);
}
