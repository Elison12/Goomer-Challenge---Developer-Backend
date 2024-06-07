using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GoomerChallenger.Application.Abstractions.Restaurantes;
using GoomerChallenger.Application.UserCases.Restaurantes.Request;
using GoomerChallenger.Application.UserCases.Restaurantes.Response;
using GoomerChallenger.Domain.Interfaces.Abstractions;
using GoomerChallenger.Domain.Interfaces.RestauranteRepository;
using GoomerChallenger.Domain.Interfaces.UnitOfWork;
using GoomerChallenger.Domain.Models;

namespace GoomerChallenger.Application.UserCases.Restaurantes.Handler
{
    public class DeleteRestauranteHandler : DeleteRestauranteInterface
    {
        private readonly IRestauranteRepository _RestauranteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRestauranteHandler(IRestauranteRepository? restauranteRepository, IUnitOfWork unitOfWork)
        {
            _RestauranteRepository = restauranteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResponse> Handler(DeleteRestauranteRequest request, CancellationToken cancellationToken)
        {
            #region Validações
            var result = request.Validar();

            if (!result.IsValid)
            {
                return new InvalidRequest(statuscode: HttpStatusCode.BadRequest,
                                             message: "Requisição inválida. Por favor, valide os dados informados.",
                                             errors: result.Errors.ToDictionary(error => error.PropertyName, error => error.ErrorMessage));
            }
            #endregion

            try
            {
                #region buscar restaurante
                var restauranteSearch = await _RestauranteRepository.GetByIdAsync(request.idRestaurenteRequest);
                
                if (restauranteSearch is null)
                {
                    return new NotFoundRestaurante(statusCode: HttpStatusCode.NotFound, message: "Restaurante não encontrado para o id informado");
                }
                #endregion

                return await DeleteRestaurante(restauranteSearch, cancellationToken);
            }
            catch (Exception)
            {
                _unitOfWork.RollBack();
                throw;
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }

        private async Task<IResponse> DeleteRestaurante(Restaurante restauranteSearch, CancellationToken cancellationToken)
        {
            _unitOfWork.BeginTransaction();

            var deleted = await _RestauranteRepository.RemoveAsync(restauranteSearch);

            if (deleted == false)
            {
                return new DeleteRestauranteError(statuscode: HttpStatusCode.InternalServerError,
                                        message: "Houve uma falha na exclusão do restaurante. Por favor, tente novamente mais tarde.");
            }


            await _unitOfWork.Commit(cancellationToken);

            return new DeletedSuccessfully(statuscode: HttpStatusCode.OK,
                                         message: $"Restaurente {restauranteSearch.Nome} excluído com sucesso.");
        }
    }
}
