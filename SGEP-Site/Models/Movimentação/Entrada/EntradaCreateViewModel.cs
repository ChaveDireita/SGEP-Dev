using SGEP_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public class EntradaCreateViewModel
    {
        public decimal Quantidade { get; set; }
        public ulong FuncionarioId { get; set; }
        public ulong MaterialId { get; set; }
        public string AlmoxarifadoId { get; set; }
    }
}
