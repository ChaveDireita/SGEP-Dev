using SGEP_Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGEP_Site.Models
{
    public class ProjetoDetailsViewModel
    {
        [Display(Name = "Código")]
        public ulong Id { get; set; }
        public string Nome { get; set; }
        [Display (Name = "Data de início")]
        public DateTime DataInicio { get; set; }
        [Display (Name = "Prazo estimado")]
        public DateTime PrazoEstimado { get; set; }
        [Display (Name = "Data de término")]
        public DateTime? DataFim { get; set; }
        public string Estado { get; set; }
        public IEnumerable<Funcionario> Funcionarios { get; set; }
    }
}
