using FluentValidation;
using GoomerChallenger.Application.UserCases.Restaurante.Request;

namespace GoomerChallenger.Application.Validators.Restaurante
{
    public class CreateRestauranteValidator : AbstractValidator<CreateRestauranteRequest>
    {
        public CreateRestauranteValidator() {

            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("O restaurante não pode ser vazio")

                .NotNull()
                .WithMessage("O restaurante não pode ser nulo");
            RuleFor(x => x.Nome)

                .NotEmpty()
                .WithMessage("O restaurante precisa ter um nome.")

                .NotNull()
                .WithMessage("O nome do restaurante não pode ser nulo");
            RuleFor(x => x.Endereco)

                .NotEmpty()
                .WithMessage("O restaurante precisa ter um endereco.")

                .NotNull()
                .WithMessage("O nome do restaurante não pode ser nulo");
            RuleFor(x => x.Foto)
                .NotEmpty()
                .WithMessage("É necessário que o restaurante tenha uma foto para cadastro")
                
                .NotEmpty()
                .WithMessage("A foto do restaurante não pode nula")

                
        }
    }
}