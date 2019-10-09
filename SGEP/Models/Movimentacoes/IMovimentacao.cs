using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using SGEP.Models;

namespace SGEP.Models.Movimentacoes
{
    public interface IMovimentacao
    {
        [Display(Name = "Código da movimentação")]
        ulong Id { get; set; }
        [Display(Name = "Data de realização")]
        DateTime Data { get; set; }
        decimal Quantidade { get; set; }
        [Display(Name = "Material")]
        ulong MaterialMovimentado { get; set; }
        [Display(Name = "Tipo")]
        string TipoMovimentacao { get; }
    }
}
