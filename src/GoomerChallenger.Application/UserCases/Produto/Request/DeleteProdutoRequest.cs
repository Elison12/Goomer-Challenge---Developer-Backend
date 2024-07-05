using FluentValidation.Results;
using GoomerChallenger.Application.Validators.Produto;
using GoomerChallenger.Domain.Interfaces.Abstractions;

namespace GoomerChallenger.Application.UserCases.Produtos.Request
{
    public class DeleteProdutoRequest : IRequest
    {
        public int idProdutoResquest { get; set; }

        public DeleteProdutoRequest(int _idProdutoRequest)
        {
            idProdutoResquest = _idProdutoRequest;
        }

        public ValidationResult Validar()
        {
            var validator = new DeleteProdutoValidator();
            return validator.Validate(this);
        }
    }
}
