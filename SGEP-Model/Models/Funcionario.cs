using SGEP_Model.Validacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGEP_Model.Models
{
    public class Funcionario :IAutoValida
    {
        public ulong Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public bool Demitido { get; set; }
        public bool Validar() => true;
    }
}
