using System;
using System.Collections.Generic;
using System.Text;

namespace SGEP_Banco.Models
{
    public class ProjetoDBModel
    {
        public ulong Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime PrazoEstimado { get; set; }
    }
}
