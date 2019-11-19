using System;
using System.Collections.Generic;
using System.Text;

namespace SGEP_Model.Models
{
    public class Sobra : Movimentacao
    {
        public string Almoxarifado { get; set; }
        public override string TipoMovimentacao => "Sobra";
    }
}
