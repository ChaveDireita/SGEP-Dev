using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public abstract class MovimentacaoDetailsViewModel
    {
        public DateTime Data { get; set; }
        public decimal Quantidade { get; set; }
        public string Material { get; set; }
    }
}
