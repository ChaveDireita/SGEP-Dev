using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SGEP.Models;

namespace SGEP.Models.Movimentacoes
{
    public interface IMovimentacao
    {
        DateTime Data { get; set; }
        decimal Quantidade { get; set; }
        Material MaterialMovimentado { get; set; }

    }
}
