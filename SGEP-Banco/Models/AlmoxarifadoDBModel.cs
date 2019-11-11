using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SGEP_Banco.Models
{
    public class AlmoxarifadoDBModel
    {
        public ulong Id { get; set; }
    }
    
    public class AlmoxarifadoMaterialDBModel
    {
        [ForeignKey(nameof(AlmoxarifadoDBModel))]
        public ulong AlmoxarifadoId { get; set; }
        [ForeignKey(nameof(MaterialDBModel))]
        public ulong MaterialId { get; set; }
        public decimal Quantidade { get; set; }
    }
}
