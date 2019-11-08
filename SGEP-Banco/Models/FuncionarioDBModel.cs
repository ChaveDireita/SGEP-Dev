using System;
using System.Collections.Generic;
using System.Text;

namespace SGEP_Banco.Models
{
    public class FuncionarioDBModel
    {
        public ulong Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public bool Deletado { get; set; }
    }
}
