using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoomerChallenger.Domain.DTO;
using GoomerChallenger.Domain.Interfaces.Services;
using GoomerChallenger.Infra.Data.Context;
using GoomerChallenger.Notification.Results;
using Microsoft.EntityFrameworkCore;

namespace GoomerChallenger.Infra.Services
{
    public class RestauranteQueriesServices : IRestauranteQueriesServices
    {
        private readonly GoomerContext _goomerContext;

        public RestauranteQueriesServices (GoomerContext goomerContext)
        {
            _goomerContext = goomerContext;
        }
         public async Task<Result<IEnumerable<RestauranteDTO>>> GetAllAsync()
        {
            try
            {
                var restaurantes = await _goomerContext
                        .Restaurante
                        .AsNoTracking()
                        .Select(x => new RestauranteDTO
                        {
                            Nome = x.Nome,
                           Endereco = x.Endereco,
                           Telefone = x.Telefone,
                           NumFuncionarios = x.NumFuncionarios,
                           Gerente = x.Gerente,
                           CaminhoFoto = x.CaminhoFoto


                        }).ToListAsync();

                return Result<IEnumerable<RestauranteDTO>>.Success(restaurantes);
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public Task<Result<RestauranteDTO>> GetBydIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<RestauranteDTO>>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
