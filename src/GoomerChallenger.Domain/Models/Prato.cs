using GoomerChallenger.Domain.Interfaces.Abstractions;
using GoomerChallenger.Notification.Entities;

namespace GoomerChallenger.Domain.Models
{
    public sealed class Prato : Entity, IValidate
    {
        public Prato(string? nome, int codigo, float valor)
        {
            Nome = nome;
            Codigo = codigo;
            this.valor = valor;
        }

        public string? Nome { get; private set; }
        public float valor { get; private set; }
        public int Codigo { get; private set; }
        
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
