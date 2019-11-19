using System;
using System.Collections.Generic;
using System.Text;

namespace SGEP_Banco.Models
{
    public class SobraDBModel
    {
        public ulong Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Quantidade { get; set; }
        public string Material { get; set; }
        public string Almoxarifado { get; set; }
    }
}
