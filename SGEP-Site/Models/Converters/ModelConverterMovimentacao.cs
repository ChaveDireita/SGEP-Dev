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

        public static MovimentacaoIndexViewModel DomainToIndexView (Entrada e) => new MovimentacaoIndexViewModel
        {
            Id = e.Id,
            Quantidade = e.Quantidade,
            Material = e.Material,
            Destino = e.AlmoxarifadoDestino,
            Data = e.Data,
            Action = "Entrada",
            Tipo = "Entrada",
        };

        public static MovimentacaoIndexViewModel DomainToIndexView (Saida s) => new MovimentacaoIndexViewModel
        {
            Id = s.Id,
            Quantidade = s.Quantidade,
            Material = s.Material,
            Destino = s.AlmoxarifadoDestino,
            Data = s.Data,
            Action = "Saida",
            Tipo = "Saída"
        };

        public static EntradaDetailsViewModel DomainToDetailsView (Entrada e) => new EntradaDetailsViewModel
        {
            Data = e.Data,
            Destino = e.AlmoxarifadoDestino,
            Material = e.Material,
            Preco = e.Preco,
            Quantidade = e.Quantidade,
        };





        public static Entrada CreateViewToDomain (EntradaCreateViewModel e, Material m, Almoxarifado a) => new Entrada ()
        {
            Data = DateTime.Now,
            Quantidade = e.Quantidade,
            Material = m.Descricao,
            Preco = e.Quantidade * m.Preco,
            AlmoxarifadoDestino = a.Nome
        };
        
        public static Saida CreateViewToDomain (SaidaCreateViewModel e, Material m, Almoxarifado ad, Almoxarifado ao) => new Saida ()
        {
            Data = DateTime.Now,
            Quantidade = e.Quantidade,
            Material = m.Descricao,
            AlmoxarifadoDestino = ad.Nome,
            AlmoxaridadoOrigem = ao.Nome,
            Funcionario = e.Funcionario
        };


    }
}
