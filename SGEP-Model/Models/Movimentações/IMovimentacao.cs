using System;
using System.Collections.Generic;
using System.Text;

namespace SGEP_Model.Models
{
    public interface IMovimentacao
    {
        ulong Id { get; set; }
        DateTime Data { get; set; }
        decimal Quantidade { get; set; }
        Material MaterialMovimentado { get; set; }
        IEstoca Destino { get; set; }
        string TipoMovimentacao { get; }
    }
}
