using GoomerChallenger.Domain.Interfaces.Abstractions;
using GoomerChallenger.Notification.Entities;
using GoomerChallenger.Notification.Extensions;
using Errors = System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>;
namespace GoomerChallenger.Domain.Models
{
    public class Cardapio : Entity, IValidate
    {

        public int idCardapio { get; set; }
        public Restaurante Restaurante { get; set; }
        public int idRestaurante { get ; set; }
        public ICollection<Prato> Pratos { get; set; }

        //public void addPratoOnCardapio(Prato prato)
        //{
        //    if (!prato.Isvalid)
        //    {
        //        return 
        //    }
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
