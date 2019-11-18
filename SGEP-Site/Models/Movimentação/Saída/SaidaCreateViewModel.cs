using SGEP_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public class SaidaCreateViewModel
    {
        public string Funcionario { get; set; }
        public ulong AlmoxarifadoDestinoId { get; set; }
        public ulong AlmoxarifadoOrigemId { get; set; }
        public ulong MaterialId { get; set; }
        public decimal Quantidade { get; set; }
    }
}
