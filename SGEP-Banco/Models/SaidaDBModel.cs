using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SGEP_Banco.Models
{
    public class SaidaDBModel
    {
        public ulong Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Quantidade { get; set; }
        [ForeignKey(nameof(MaterialDBModel))]
        public ulong MaterialID { get; set; }
        [ForeignKey(nameof(ProjetoDBModel))]
        public ulong ProjetoID { get; set; }
        [ForeignKey(nameof(FuncionarioDBModel))]
        public ulong FuncionarioID { get; set; }
    }
}
