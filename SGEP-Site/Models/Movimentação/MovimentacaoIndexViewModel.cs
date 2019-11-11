using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public struct MovimentacaoIndexViewModel : IComparer<MovimentacaoIndexViewModel>
    {
        public ulong Id { get; set; }
        public DateTime Data { get; set; }
        [Display(Name = "Almoxarifado de Destino")]
        public string Destino { get; set; }
        public string Material { get; set; }
        public decimal Quantidade { get; set; }
        public string Action { get; set; }

        public int Compare (MovimentacaoIndexViewModel x, MovimentacaoIndexViewModel y) => x.Data.CompareTo (y);
    }
}
