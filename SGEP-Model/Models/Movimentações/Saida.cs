using SGEP_Model.Validacao;
using System;

namespace SGEP_Model.Models
{
    public class Saida : IMovimentacao, IAutoValida
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
        public Material MaterialMovimentado { get; set; }
        public Projeto ProjetoSolicitante { get; set; }
        public Funcionario Solicitante { get; set; }
        public string TipoMovimentacao => "Saída";
        public bool Validar() => true;
    }
}
