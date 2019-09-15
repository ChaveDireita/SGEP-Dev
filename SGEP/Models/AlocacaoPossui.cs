using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModelPFCII.Models
{
    public class AlocacaoPossui : IAutoValida
    {
        public ulong Quantidade { get; set; }
        [ForeignKey("Material")]
        public ulong CodMaterial { get; set; }
        [ForeignKey("Projeto")]
        public ulong CodProjeto { get; set; }

        public bool Validar() => Quantidade >= 0;
    }
}
