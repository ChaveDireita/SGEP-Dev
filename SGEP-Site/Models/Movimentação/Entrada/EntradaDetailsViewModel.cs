using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public class EntradaDetailsViewModel : MovimentacaoDetailsViewModel
    {
        public string Destino { get; set; }
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
    }
}
