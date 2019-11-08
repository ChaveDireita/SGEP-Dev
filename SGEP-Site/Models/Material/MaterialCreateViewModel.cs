using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public class MaterialCreateViewModel
    {
//        [RegularExpression("[0-9]+", ErrorMessage = "Apenas n�meros s�o permitidos nesse campo \"Id.\"")]
//        [Required(ErrorMessage = "Esse campo � obrigat�rio")]
//        [Display(Name = "C�digo")]
//        public ulong Id { get; set; }
        [RegularExpression("[A-z ������������������������������]+", ErrorMessage = "Apenas letras s�o permitidas no campo \"Descri��o.\"")]
        [Required(ErrorMessage = "Este campo � obrigat�rio.")]
        [Display(Name = "Descri��o")]
        public string Descricao { get; set; }
        [RegularExpression("[A-z ������������������������������]+", ErrorMessage = "Apenas letras s�o permitidas no campo \"Unidade.\"")]
        [Required(ErrorMessage = "Este campo � obrigat�rio.")]
        public string Unidade { get; set; }
        [RegularExpression("[0-9]+", ErrorMessage = "Apenas n�meros s�o permitidos nesse campo \"Pre�o.\"")]
        [Required(ErrorMessage = "Esse campo � obrigat�rio")]
        [Display(Name = "Pre�o")]
        public decimal Preco { get; set; }
    }
}
