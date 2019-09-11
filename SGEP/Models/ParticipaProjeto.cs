using SGEP.Models.Validacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP.Models
{
    public class ParticipaProjeto : IAutoValida
    {
        public ulong idFuncionario { get; set; }
        public ulong idProjeto { get; set; }
    }
}
