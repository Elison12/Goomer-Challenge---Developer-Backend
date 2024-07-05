
using System.Runtime.CompilerServices;
using GoomerChallenger.Domain.Interfaces.Abstractions;
using GoomerChallenger.Notification.Entities;
using GoomerChallenger.Notification.Extensions;
using Errors = System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>;

namespace GoomerChallenger.Domain.Models
{
    public sealed class Produto : Entity, IValidate
    {
        public int IdProduto {  get; private set; }
        public string? Nome { get; private set; }
        public String Codigo { get; private set; }
        public float Valor { get; private set; }
        public String Categoria { get; private set; }
        public string DtValidade { get; private set; }
        public string DtAquisicao { get; private set; }
        public string Departamento { get; private set; }
        public int Lote { get; private set; }
        public  bool IsPromocao { get; set; }
        public string? DescricaoPromocao { get; set; }
        public float PrecoPromocional { get; set; }
        public string CaminhoFoto { get; set; } 

        public Produto() { }

        public Produto(string? nome, string codigo, float valor, string categoria, string dtValidade, string dtAquisicao, string departamento, int lote, string caminhoFoto)
        {
            //IdProduto = id;
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

        public void SetValor(float valor)
        {
            Valor = valor;
        }

        public void Validate()
        {
            var errors = new Errors();
            errors.AddRange(this.CheckIfPropertiesIsNull());
            if (errors.Count > 0)
            {
                AddNotification(errors);
            }
        }
    }
}
