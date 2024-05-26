using FluentValidation.Results;
using GoomerChallenger.Application.Validators.Restaurante;
using GoomerChallenger.Domain.Interfaces.Abstractions;
using Microsoft.AspNetCore.Http;
namespace GoomerChallenger.Application.UserCases.Restaurante.Request
{
    public class CreateRestauranteRequest : IRequest
    {

        public IFormFile Foto { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }


        public CreateRestauranteRequest(IFormFile foto, string nome, string endereco)
        {
            Foto = foto;
            Nome = nome;
            Endereco = endereco;
        }

        public ValidationResult Validar()
        {
            var validator = new CreateRestauranteValidator();
            return validator.Validate(this);
        }
    }
}
