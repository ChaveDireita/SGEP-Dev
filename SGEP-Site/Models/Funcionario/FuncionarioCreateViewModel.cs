using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public class FuncionarioCreateViewModel
    {
        [RegularExpression("[A-z ÁÁÄáàäÉÈËéèëÍÌÏíìïÓÒÖóòöÚÙÜúùü]+", ErrorMessage = "Apenas letras são permitidas no campo \"Nome completo.\"")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [Display(Name = "Nome completo")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Cargo { get; set; }
    }
}
