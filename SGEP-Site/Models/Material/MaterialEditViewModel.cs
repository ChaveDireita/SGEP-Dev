using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public class MaterialEditViewModel
    {
        [Display(Name = "C�digo")]
        public ulong Id { get; set; }
        [Display(Name = "Descri��o")]
        public string Descricao { get; set; }
        public string Unidade { get; set; }
        [Display(Name = "Pre�o")]
        public decimal Preco { get; set; }
    }
}
