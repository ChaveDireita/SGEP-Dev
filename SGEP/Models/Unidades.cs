using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP.Models
{
    public class Unidades
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Unidade { get; set; }
    }
}
