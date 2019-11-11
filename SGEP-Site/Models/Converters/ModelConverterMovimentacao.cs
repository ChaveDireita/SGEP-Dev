using SGEP_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public sealed class ModelConverterMovimentacao
    {
        private ModelConverterMovimentacao () { }

        public static MovimentacaoIndexViewModel DomainToIndex (Entrada e) => new MovimentacaoIndexViewModel
        {
            Id = e.Id,
            Quantidade = e.Quantidade,
            Material = e.Material,
            Destino = e.AlmoxarifadoDestino,
            Data = e.Data,
            Action = "Entrada"
        };

        public static MovimentacaoIndexViewModel DomainToIndex (Saida s) => new MovimentacaoIndexViewModel
        {
            Id = s.Id,
            Quantidade = s.Quantidade,
            Material = s.Material,
            Destino = s.AlmoxarifadoDestino,
            Data = s.Data,
            Action = "Saida"
        };

    }
}
