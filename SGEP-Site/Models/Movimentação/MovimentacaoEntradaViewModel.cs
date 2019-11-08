using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models {
    public class MovimentacaoEntradaViewModel : IMovimentacao {
        public ulong Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Quantidade { get; set; }
        public string MaterialMovimentado { get; set; }
        public string TipoMovimentacao { get; set; }
        public string Action { get; set; }
        public string FuncionarioNome { get; set; }
        public decimal Preco { get; set; }
    }
}
