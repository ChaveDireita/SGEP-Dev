using SGEP.Models.Validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP.Models
{
    public class ParticipaProjeto //: IAutoValida
    {
        [ForeignKey("Material")]
        public ulong IdFuncionario { get; set; }
        [ForeignKey("Material")]
        public ulong IdProjeto { get; set; }
    }
}
