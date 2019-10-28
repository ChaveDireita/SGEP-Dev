using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public class MovimentacoesCreateViewModel
    {
        [RegularExpression("[0-9]+", ErrorMessage = "Apenas n�meros s�o permitidos nesse campo \"Id.\"")]
        [Required(ErrorMessage = "Esse campo � obrigat�rio")]
        [Display(Name = "C�digo")]
        public ulong Id { get; set; }
        [Required(ErrorMessage = "Esse campo � obrigat�rio")]
        public DateTime Data { get; set; }
        [RegularExpression("[0-9]+", ErrorMessage = "Apenas n�meros s�o permitidos nesse campo \"Pre�o.\"")]
        [Required(ErrorMessage = "Esse campo � obrigat�rio")]
        [Display(Name = "Pre�o")]
        public decimal Preco { get; set; }
        [RegularExpression("[0-9]+", ErrorMessage = "Apenas n�meros s�o permitidos nesse campo \"Quantidade.\"")]
        [Required(ErrorMessage = "Esse campo � obrigat�rio")]
        public decimal Quantidade { get; set; }
    }
}
