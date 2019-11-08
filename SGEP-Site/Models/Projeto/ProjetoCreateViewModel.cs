using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public class ProjetoCreateViewModel
    {
        [RegularExpression("^[ ]", ErrorMessage = "Insira um nome para o projeto")]
        public string Nome { get; set; }
        [Display(Name = "Data de início")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }
        [Display(Name = "Prazo estimado")]
        [DataType(DataType.Date)]
        public DateTime PrazoEstimado { get; set; }
    }
}
