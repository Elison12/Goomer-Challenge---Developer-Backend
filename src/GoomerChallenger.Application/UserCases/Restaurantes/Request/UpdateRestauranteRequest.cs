
using FluentValidation.Results;
using GoomerChallenger.Application.Validators.Restaurante;
using GoomerChallenger.Domain.Interfaces.Abstractions;
using Microsoft.AspNetCore.Http;

namespace GoomerChallenger.Application.UserCases.Restaurantes.Request
{
    public class UpdateRestauranteRequest : IRequest
    {
        public int idRestauranteBusca { get; set; }
        public IFormFile Foto { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Gerente { get; set; }
        public int NumFuncionarios { get; set; }

        public UpdateRestauranteRequest(IFormFile foto, string nome, string endereco, string telefone, string gerente, int numFuncionarios)
        {
            Foto = foto;
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Gerente = gerente;
            NumFuncionarios = numFuncionarios;
        }

        public ValidationResult Validar()
        {
            var validator = new UpdateRestauranteValidator();
            return validator.Validate(this);
        }
    }
}
