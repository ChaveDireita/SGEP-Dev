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
        [ForeignKey("Funcionario")]
        public ulong CodFuncionario { get; set; }
        [ForeignKey("Projeto")]
        public ulong CodProjeto { get; set; }

        public virtual Funcionario Funcionario { get; set; }
        public virtual Projeto Projeto { get; set; }

    }
}
