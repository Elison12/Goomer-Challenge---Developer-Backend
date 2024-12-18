﻿using GoomerChallenger.Domain.Interfaces.Abstractions;
using GoomerChallenger.Notification.Entities;
using GoomerChallenger.Notification.Extensions;
using Errors = System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>;
namespace GoomerChallenger.Domain.Models
{
    public sealed class Restaurante : Entity, IValidate
    {
        public int idRestaurante { get; private set; }
        public string Nome { get;  set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public int NumFuncionarios { get; set; }
        public string Gerente { get; set; }
        public Cardapio cardapio { get; set; }
        public String CaminhoFoto { get; set; }
        //public ICollection<Prato> Cardapio { get; set; } //retirar
        public Restaurante() { }

        public Restaurante(string nome, string endereco, string caminhoFoto, string telefone, string gerente, int numFuncionarios)
        {
            //idRestaurante = id;
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            NumFuncionarios = numFuncionarios;
            Gerente = gerente;
            CaminhoFoto = caminhoFoto;
            //Cardapio = cardapio;
        }
        public void SetCardapio (Cardapio _cardapio)
        {
            cardapio = _cardapio;
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
