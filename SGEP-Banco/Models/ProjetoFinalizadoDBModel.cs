using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SGEP_Banco.Models
{
    public class ProjetoFinalizadoDBModel
    {
        [Key]
        [ForeignKey(nameof(ProjetoDBModel))]
        public ulong Id { get; set; }
        public DateTime DataFim { get; set; }
    }
}
