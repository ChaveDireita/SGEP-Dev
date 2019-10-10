using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using SGEP.Models.Movimentacoes;
using SGEP.Models.Validacao;

namespace SGEP.Models
{
    public class MovimentacaoCompra : IMovimentacao, IAutoValida
    {
        [Key]
        [Display(Name = "Código da movimentação")]
        public ulong Id { get; set; }
        [Display(Name = "Data de realização")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public decimal Quantidade { get; set; }
        [Display(Name ="Material")]
        [ForeignKey(nameof(Material))]
        public ulong MaterialMovimentado { get; set; }
        [Display(Name = "Tipo")]
        public string TipoMovimentacao { get => "Compra"; }

        public bool Validar() => !(MaterialMovimentado == null || Quantidade < 0);
    }
}
