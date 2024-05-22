
using GoomerChallenger.Domain.Interfaces.Abstractions;
using GoomerChallenger.Notification.Entities;

using Errors = System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>;

namespace GoomerChallenger.Domain.Models
{
    public sealed class Produto : Entity, IValidate
    {
        public string? Nome { get; private set; }
        public int Codigo { get; private set; }
        public float Valor { get; private set; }
        public String Categoria { get; private set; }
        public DateTime DtValidade { get; private set; }
        public DateTime DtAquisicao { get; private set; }
        public string Departamento { get; private set; }
        public int Lote { get; private set; }

        public Produto() { }

        public Produto(string? nome, int codigo, float valor, string categoria, DateTime dtValidade, DateTime dtAquisicao, string departamento, int lote)
        {
            Nome = nome;
            Codigo = codigo;
            Valor = valor;
            Categoria = categoria;
            DtValidade = dtValidade;
            DtAquisicao = dtAquisicao;
            Departamento = departamento;
            Lote = lote;
        }

        public void SetValor(float valor)
        {
            Valor = valor;
        }

        public void Validate()
        {
            //var errors = new Errors();
            //errors.AddRange(this.CheckIfPropertiesIsNull());
            //if (errors.Count > 0)
            //{
            //    AddNotification(errors);
            //}
        }
    }
}
