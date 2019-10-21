using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public struct FuncionarioViewModel
    {
        public ulong Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Demitido { get; set; }
    }
}
