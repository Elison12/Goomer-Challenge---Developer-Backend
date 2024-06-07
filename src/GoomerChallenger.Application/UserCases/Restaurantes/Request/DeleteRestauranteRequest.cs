using FluentValidation.Results;
using GoomerChallenger.Application.Validators.Restaurante;
using GoomerChallenger.Domain.Interfaces.Abstractions;

namespace GoomerChallenger.Application.UserCases.Restaurantes.Request
{
    public class DeleteRestauranteRequest : IRequest
    {
        public int idRestaurenteRequest { get; set; }
        
        public DeleteRestauranteRequest (int _idRestauranteRequest)
        {
            idRestaurenteRequest = _idRestauranteRequest;
        }

        public ValidationResult Validar()
        {
            var validator = new DeleteRestauranteValidator();
            return validator.Validate(this);
        }
    }
}
