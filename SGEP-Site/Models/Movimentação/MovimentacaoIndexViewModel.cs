using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public struct MovimentacaoIndexViewModel : IComparable<MovimentacaoIndexViewModel>
    {
        public ulong Id { get; set; }
        public DateTime Data { get; set; }
        [Display(Name = "Almoxarifado de Destino")]
        public string Destino { get; set; }
        public string Material { get; set; }
        public decimal Quantidade { get; set; }
        public string Action { get; set; }
        public string Tipo { get; set; }

        public int CompareTo (MovimentacaoIndexViewModel other) => -Data.CompareTo (other.Data);
    }
}
