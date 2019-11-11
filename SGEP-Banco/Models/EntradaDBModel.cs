using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SGEP_Banco.Models
{
    public class EntradaDBModel
    {
        public ulong Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Preco { get; set; }
        public decimal Quantidade { get; set; }
        public string Material { get; set; }//Material movimentado
        public string AlmoxarifadoDestino { get; set; }
    }
}
