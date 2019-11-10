using SGEP_Model.Validacao;
using System;

namespace SGEP_Model.Models
{
    public class Entrada : IMovimentacao, IAutoValida
    {
        public ulong Id { get; set; }
        public DateTime Data { get; set; }

        private decimal _preco;
        public decimal Preco
        {
            get => _preco;
            set
            {
                if (value > 0)
                    _preco = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }

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

        public Material MaterialMovimentado { get; set; }
        public string TipoMovimentacao => "Entrada";
        public IEstoca Destino { get; set; }
        public bool Validar() => true;
    }
}
