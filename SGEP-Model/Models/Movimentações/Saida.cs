using SGEP_Model.Validacao;
using System;

namespace SGEP_Model.Models
{
    public class Saida : Movimentacao, IAutoValida
    {
        public string TipoMovimentacao => "Saída";

        public bool Validar() => true;
    }
}
