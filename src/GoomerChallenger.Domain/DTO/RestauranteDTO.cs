using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoomerChallenger.Domain.Models;

namespace GoomerChallenger.Domain.DTO
{
    public class RestauranteDTO
    {
        public int ID { get; set; }
        public string Nome { get;  set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public int NumFuncionarios { get; set; }
        public string Gerente { get; set; }
        public String CaminhoFoto { get; set; }
    }
}
