using FluentValidation;
using GoomerChallenger.Application.UserCases.Produtos.Request;

namespace GoomerChallenger.Application.Validators.Produto
{
    public class DeleteProdutoValidator : AbstractValidator<DeleteProdutoRequest>
    {
        public DeleteProdutoValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A requisição não pode ser vazia.");
            RuleFor(x => x.idProdutoResquest)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .WithMessage("O id passado precisa ser maior ou igual a zero.");
        }
    }
}
