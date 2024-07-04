using FluentValidation.Results;
using GoomerChallenger.Application.Validators.Produto;
using GoomerChallenger.Domain.Interfaces.Abstractions;
using Microsoft.AspNetCore.Http;

namespace GoomerChallenger.Application.UserCases.Produtos.Request
{
    public class CreateProdutoRequest : IRequest
    {

        public string? Nome { get; private set; }
        public String Codigo { get; private set; }
        public float Valor { get; private set; }
        public String Categoria { get; private set; }
        public string DtValidade { get; private set; }
        public string DtAquisicao { get; private set; }
        public string Departamento { get; private set; }
        public int Lote { get; private set; }
        public bool IsPromocao { get; set; }
        public string DescricaoPromocao { get; set; }
        public float PrecoPromocional { get; set; }
        public IFormFile CaminhoFoto { get; set; }

        public CreateProdutoRequest(string? nome, string codigo, float valor, string categoria, string dtValidade, string dtAquisicao, string departamento, int lote, IFormFile caminhoFoto)
        {
            Nome = nome;
            Codigo = codigo;
            Valor = valor;
            Categoria = categoria;
            DtValidade = dtValidade;
            DtAquisicao = dtAquisicao;
            Departamento = departamento;
            Lote = lote;
            CaminhoFoto = caminhoFoto;
        }

        public ValidationResult Validar()
        {
            var validator = new CreateProdutoValidator();
            return validator.Validate(this);
        }
    }
}
