using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public class FuncionarioEditViewModel
    {
        [Display (Name = "Código")]
        public ulong Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Demitido { get; set; }
    }
}
