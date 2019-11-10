using SGEP_Model.Validacao;
using System;

namespace SGEP_Model.Models
{
    public class Entrada : Movimentacao, IAutoValida
    {
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
        public string TipoMovimentacao => "Entrada";
        public bool Validar() => true;
    }
}
