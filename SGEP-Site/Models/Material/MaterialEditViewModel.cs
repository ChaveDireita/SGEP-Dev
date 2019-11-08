using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public class MaterialEditViewModel
    {
        [Display(Name = "Código")]
        public ulong Id { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public string Unidade { get; set; }
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
    }
}
