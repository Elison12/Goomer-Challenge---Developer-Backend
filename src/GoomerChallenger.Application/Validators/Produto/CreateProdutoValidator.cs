using FluentValidation;
using GoomerChallenger.Application.UserCases.Produto.Request;

namespace GoomerChallenger.Application.Validators.Produto
{
    public class CreateProdutoValidator : AbstractValidator<CreateProdutoRequest>
    {
        public CreateProdutoValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("O produto não pode ser vazio.")

                .NotNull()
                .WithMessage("O produto não pode ser nulo.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O produto precisa de um nome");

            RuleFor(x => x.Categoria)
                .NotEmpty()
                .WithMessage("O produto precisa de uma categoria");

            RuleFor(x => x.Foto)
                .NotEmpty()
                .WithMessage("É necessario adicionar uma foto para o produto");
        }
    }
}
