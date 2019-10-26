using SGEP_Model.Validacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGEP_Model.Models
{
    public class Material : IAutoValida
    {
        public ulong Id { get; set; }
        public string Descricao { get; set; }

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
        public string Unidade { get; set; }
        public bool Validar() => true;
    }
}
