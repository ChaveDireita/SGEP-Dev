using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SGEP_Banco.Models
{
    public class SaidaDBModel
    {
        public ulong Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Quantidade { get; set; }
        public string Material { get; set; }
        public string AlmoxarifadoDestino { get; set; }
        public string AlmoxarifadoOrigem { get; set; }
        public string Funcionario { get; set; }
    }
}
