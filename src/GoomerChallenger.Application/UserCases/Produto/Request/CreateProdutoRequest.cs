
using FluentValidation.Results;
using GoomerChallenger.Domain.Interfaces.Abstractions;
using Microsoft.AspNetCore.Http;

namespace GoomerChallenger.Application.UserCases.Produto.Request
{
    public class CreateProdutoRequest : IRequest
    {
        public CreateProdutoRequest(string? nome, float preco, string? categoria, IFormFile? foto)
        {
            Nome = nome;
            Preco = preco;
            Categoria = categoria;
            Foto = foto;
        }

        public  string? Nome { get; set; }
        public float Preco { get; set; }
        public IFormFile? Foto { get; set; }
        public string? Categoria { get; set; }
        
        public ValidationResult Validar()
        {
            var validator = new CreateProdutoValidator();
            return validator.Validate(this);
        }
        
    }
}
