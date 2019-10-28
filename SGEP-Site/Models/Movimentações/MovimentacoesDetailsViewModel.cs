using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public class MovimentacoesDetailsViewModel
    {
        public ulong Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Preco { get; set; }
        public decimal Quantidade { get; set; }
    }
}
