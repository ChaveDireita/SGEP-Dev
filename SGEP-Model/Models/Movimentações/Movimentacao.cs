using System;
using System.Collections.Generic;
using System.Text;

namespace SGEP_Model.Models
{
    public abstract class Movimentacao
    {
        public ulong Id { get; set; }
        public DateTime Data { get; set; }
        private decimal _quantidade;
        public decimal Quantidade
        {
            get => _quantidade;
            set
            {
                if (value > 0)
                    _quantidade = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public string Material { get; set; }
        public abstract string TipoMovimentacao { get; }
        public string AlmoxarifadoDestino { get; set; }
    }
}
