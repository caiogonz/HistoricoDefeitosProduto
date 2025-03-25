using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoDefeitosProduto
{
    public class ProductDefect
    {
        public string Funcionario { get; set; }
        public string Turno { get; set; }
        public string Linha { get; set; }
        public string Setor { get; set; }
        public string NumeroSerie { get; set; }
        public string NomeProduto { get; set; }
        public string Defeito { get; set; }
        public string Origem { get; set; }
        public string Suborigem { get; set; }
        public string Acao { get; set; }
        public DateTime DataHora { get; set; } 
    }

}
