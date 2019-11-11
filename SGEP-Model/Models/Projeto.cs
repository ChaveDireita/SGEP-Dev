using SGEP_Model.Validacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGEP_Model.Models
{
    public class Projeto : IAutoValida
    {
        public ulong Id { get; set; }
        public ulong AlmoxarifadoId { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime PrazoEstimado { get; set; }
        public DateTime? DataFim { get; set; }
        public EstadoProjeto Estado { get; set; } = EstadoProjeto.Andamento;

        public void Finalizar (DateTime fim) 
        {
            if (fim < DataInicio)
                throw new ArgumentOutOfRangeException ("A data final deve ser maior que a data inicial");
            DataFim = fim;
            Estado = EstadoProjeto.Finalizado;
        }

        public bool Validar() => true;
    }
}
