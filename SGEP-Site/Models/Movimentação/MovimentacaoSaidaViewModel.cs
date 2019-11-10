using System;

namespace SGEP_Site.Models
{
    public class MovimentacaoSaidaViewModel : Movimentacao
    {
        public AlmoxarifadoViewModel Origem { get; set; }
    }
}
