using GoomerChallenger.Domain.Interfaces.Abstractions;
using GoomerChallenger.Notification.Entities;
using GoomerChallenger.Notification.Extensions;
using Errors = System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>;
namespace GoomerChallenger.Domain.Models
{
    public sealed class Prato : Entity, IValidate
    {
        public int IdPrato { get; set; }
        public string? Nome { get; private set; }
        public float valor { get; private set; }
        public int Codigo { get; private set; }
        public int RestauranteId { get; set; }
        public Restaurante Restaurante { get; set; }
        public Cardapio Cardapio { get; set; }
        public int idCardapio { get; set; }
        public string CaminhoFoto { get; set; }
        
        public Prato() { }

        public Prato(int idPrato, string? nome, float valor, int codigo, int restauranteId, Restaurante restaurante, string caminhoFoto)
        {
            IdPrato = idPrato;
            Nome = nome;
            this.valor = valor;
            Codigo = codigo;
            RestauranteId = restauranteId;
            Restaurante = restaurante;
            CaminhoFoto = caminhoFoto;
        }


        //public Prato(string? nome, int codigo, float valor)
        //{
        //    Nome = nome;
        //    Codigo = codigo;
        //    this.valor = valor;
        //}
        public void Validate()
        {
            var erros = new Errors();
            erros.AddRange(this.CheckIfPropertiesIsNull());
            if (erros.Count > 0)
            {
                AddNotification(erros);
            }
        }
    }
}
