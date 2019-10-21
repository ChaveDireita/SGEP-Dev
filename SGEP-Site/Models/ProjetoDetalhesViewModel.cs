using SGEP_Model.Models;
using System;
using System.Collections.Generic;

namespace SGEP_Site.Models
{
    public class ProjetoDetalhesViewModel
    {
        public ulong Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime PrazoEstimado { get; set; }
        public DateTime? DataFim { get; set; }
        public string Estado { get; set; }
        public IEnumerable<Funcionario> Funcionarios { get; set; }
    }
}
