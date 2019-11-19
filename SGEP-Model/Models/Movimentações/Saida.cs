using SGEP_Model.Validacao;
using System;

namespace SGEP_Model.Models
{
    public class Saida : Movimentacao, IAutoValida
    {
        public override string TipoMovimentacao => "Saída";
        public string Destino { get; set; }
        public string Origem { get; set; }
        public string Funcionario { get; set; }
        public bool Validar() => true;
    }
}
