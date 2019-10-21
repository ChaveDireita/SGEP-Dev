using System;

namespace SGEP_Site.Models
{
    public struct MovimentacaoViewModel
    {
        public ulong Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Quantidade { get; set; }
        public string MaterialMovimentado { get; set; }
        public string TipoMovimentacao { get; set; }
    }
}
