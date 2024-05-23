using GoomerChallenger.Domain.Interfaces.Abstractions;
using GoomerChallenger.Notification.Entities;
using GoomerChallenger.Notification.Extensions;
using Errors = System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>;
namespace GoomerChallenger.Domain.Models
{
    public sealed class Restaurante : Entity, IValidate
    {
        public int idRestaurante { get; private set; }
        public string Nome { get; private set; }

        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public int NumFuncionarios { get; set; }
        public string Gerente { get; set; }
        public ICollection<Prato> Cardapio { get; set; }
        public Restaurante() { }

        public Restaurante(int id, string nome, string endereco, string telefone, int numFuncionarios, string gerente, List<Prato> cardapio)
        {
            idRestaurante = id;
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            NumFuncionarios = numFuncionarios;
            Gerente = gerente;
            Cardapio = cardapio;
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
