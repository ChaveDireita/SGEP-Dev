using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public class MovimentacoesCreateViewModel
    {
        [RegularExpression("[0-9]+", ErrorMessage = "Apenas números são permitidos nesse campo \"Id.\"")]
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Display(Name = "Código")]
        public ulong Id { get; set; }
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public DateTime Data { get; set; }
        [RegularExpression("[0-9]+", ErrorMessage = "Apenas números são permitidos nesse campo \"Preço.\"")]
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
        [RegularExpression("[0-9]+", ErrorMessage = "Apenas números são permitidos nesse campo \"Quantidade.\"")]
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public decimal Quantidade { get; set; }
    }
}
