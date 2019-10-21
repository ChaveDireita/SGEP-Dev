using System;
using System.Collections.Generic;
using System.Text;

namespace SGEP_Banco.Models
{
    public class MaterialDBModel
    {
        public ulong Id { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public decimal Quantidade { get; set; }
        public string Unidade { get; set; }
    }
}
