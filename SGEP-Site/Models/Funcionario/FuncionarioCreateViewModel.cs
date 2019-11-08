using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public class FuncionarioCreateViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [RegularExpression("[0-9]{4}", ErrorMessage = "Apenas números são permitidos nesse campo \"Id.\"")]
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Display(Name = "Código")]
        public string Id { get; set; }
        [RegularExpression("[A-z ÁÁÄáàäÉÈËéèëÍÌÏíìïÓÒÖóòöÚÙÜúùü]+", ErrorMessage = "Apenas letras são permitidas no campo \"Nome completo.\"")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [Display(Name = "Nome completo")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [RegularExpression("[A-z ÁÁÄáàäÉÈËéèëÍÌÏíìïÓÒÖóòöÚÙÜúùü]+", ErrorMessage = "Apenas letras são permitidas no campo \"Cargo.\"")]
        public string Cargo { get; set; }
    }
}
