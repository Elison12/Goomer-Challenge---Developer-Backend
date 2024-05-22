using System.Reflection.Metadata;
using GoomerChallenger.Domain.Interfaces.Abstractions;
using GoomerChallenger.Notification.Entities;

using Errors = System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>;

namespace GoomerChallenger.Domain.Models
{
    public sealed class Restaurante : Entity, IValidate
    {
        public void Validate()
        {
            var errors = new Errors();
           // errors.AddRange(this.Check)
             
        }
    }
}
