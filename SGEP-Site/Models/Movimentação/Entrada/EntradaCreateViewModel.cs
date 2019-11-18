using SGEP_Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public class EntradaCreateViewModel
    {
        [RegularExpression("[0-9]+([.][0-9]+)?", ErrorMessage = "Apenas números são permitidos no campo \"Quantidade\"")]
        public decimal Quantidade { get; set; }
        [Display(Name = "Material")]
        public ulong MaterialId { get; set; }
        [Display(Name = "Almoxarifado")]
        public ulong AlmoxarifadoId { get; set; }
    }
}
