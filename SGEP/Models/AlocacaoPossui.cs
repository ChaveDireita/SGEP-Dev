using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using SGEP.Models.Validacao;

namespace SGEP.Models
{
    public class Transacao : IAutoValida
    {
        public ulong Quantidade { get; set; }
        [ForeignKey("Material")]
        public ulong CodMaterial { get; set; }
        [ForeignKey("Projeto")]
        public ulong CodProjeto { get; set; }
        public DateTime Data { get; set; }
        public virtual Material Material { get; set; }
        public virtual Projeto Projeto { get; set; }

        public bool Validar() => Quantidade >= 0;
    }
}
