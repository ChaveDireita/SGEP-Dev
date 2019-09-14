using SGEP.Models.Validacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP.Models
{
    public class ParticipaProjeto //: IAutoValida
    {
        public ulong IdFuncionario { get; set; }
        public ulong IdProjeto { get; set; }
    }
}
