using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GoomerChallenger.Application.Interfaces.Restaurante;
using GoomerChallenger.Application.UserCases.Restaurante.Request;
using GoomerChallenger.Domain.Interfaces.Abstractions;
using GoomerChallenger.Domain.Interfaces.UnitOfWork;

namespace GoomerChallenger.Application.UserCases.Restaurante.Handler
{
    public class CreateRestauranteHandler : ICreateRestaurante
    {
        private readonly IUnitOfWork _IUnitOfWork;

        public CreateRestauranteHandler(IUnitOfWork iUnitOfWork)
        {
            _IUnitOfWork = iUnitOfWork;
        }

        public Task<IResponse> Handle(CreateRestauranteRequest request)
        {
            #region validações

            var result = request.Validar();

            if (!result.IsValid)
                return new InvalidRequest(
                       ActivityStatusCode: HttpStatusCode.BadRequest,
                       Message: "Requisição invalida. Verifique os dados informados",
                       Errors: result.Errors.ToDictionary(error => error.PropertyName, error => error.ErrorMessage)
                    );
            #endregion
        }
    }
}
