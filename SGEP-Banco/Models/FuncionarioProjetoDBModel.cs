using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SGEP_Banco.Models
{
    public class FuncionarioProjetoDBModel
    {
        [ForeignKey(nameof(FuncionarioDBModel))]
        public ulong FuncionarioId { get; set; }
        [ForeignKey(nameof(ProjetoDBModel))]
        public ulong ProjetoId { get; set; }
    }
}
