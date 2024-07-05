using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoomerChallenger.Domain.DTO
{
    public class ProdutoDTO
    {
        public int Id { get;  set; }
        public string? Nome { get;  set; }
        public string Codigo { get;  set; }
        public float Valor { get;  set; }
        public string Categoria { get;  set; }
        public string DtValidade { get;  set; }
        public string DtAquisicao { get;  set; }
        public string Departamento { get;  set; }
        public int Lote { get;  set; }
        public bool IsPromocao { get; set; }
        public string CaminhoFoto { get; set; }
    }
}
