using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public class MaterialCreateViewModel
    {
//        [RegularExpression("[0-9]+", ErrorMessage = "Apenas números são permitidos nesse campo \"Id.\"")]
//        [Required(ErrorMessage = "Esse campo é obrigatório")]
//        [Display(Name = "Código")]
//        public ulong Id { get; set; }
        [RegularExpression("[A-z ÁÁÄáàäÉÈËéèëÍÌÏíìïÓÒÖóòöÚÙÜúùü]+", ErrorMessage = "Apenas letras são permitidas no campo \"Descrição.\"")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [RegularExpression("[A-z ÁÁÄáàäÉÈËéèëÍÌÏíìïÓÒÖóòöÚÙÜúùü]+", ErrorMessage = "Apenas letras são permitidas no campo \"Unidade.\"")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Unidade { get; set; }
        [RegularExpression("[0-9]+", ErrorMessage = "Apenas números são permitidos nesse campo \"Preço.\"")]
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
    }
}
