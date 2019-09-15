using SGEP.Models.Validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP.Models
{
    public class ParticipaProjeto : IAutoValida
    {
        [Key]
        public ulong idParticipacao { get; set; }
        public ulong idFuncionario { get; set; }
        public ulong idProjeto { get; set; }

        public virtual Funcionario Funcionario { get; set; }
        public virtual Projeto Projeto { get; set; }

        public bool Validar()
        {
            throw new NotImplementedException();
        }
    }
}
