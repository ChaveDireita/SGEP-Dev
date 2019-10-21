using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public struct MaterialViewModel
    {
        public ulong Id { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public decimal Quantidade { get; set; }
        public string Unidade { get; set; }
    }
}
