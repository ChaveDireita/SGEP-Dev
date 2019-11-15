using System;
using System.Collections.Generic;
using System.Text;

using SGEP_Model.Models;

namespace SGEP_Banco.Models
{
    public class ModelConverter
    {
        public static FuncionarioDBModel DomainToDB(Funcionario funcionarioDomain) => new FuncionarioDBModel
        {
            Id = funcionarioDomain.Id,
            Nome = funcionarioDomain.Nome,
            Cargo = funcionarioDomain.Cargo,
            Demitido = funcionarioDomain.Demitido
        };

        public static MaterialDBModel DomainToDB(Material materialDomain) => new MaterialDBModel
        {
            Id = materialDomain.Id,
            Descricao = materialDomain.Descricao,
            Preco = materialDomain.Preco,
            Quantidade = materialDomain.Quantidade,
            Unidade = materialDomain.Unidade
        };

        public static (ProjetoDBModel projeto, ProjetoFinalizadoDBModel projetoFinalizado) DomainToDB(Projeto projeto)
        {
            ProjetoDBModel projetoDB = new ProjetoDBModel ()
            {
                Id = projeto.Id,
                AlmoxarifadoId = projeto.AlmoxarifadoId,
                Nome = projeto.Nome,
                DataInicio = projeto.DataInicio,
                PrazoEstimado = projeto.PrazoEstimado
            };

            ProjetoFinalizadoDBModel projetoFinalizadoDB;

            if (projeto.DataFim != null)
            {
                projetoFinalizadoDB = new ProjetoFinalizadoDBModel()
                {
                    Id = projeto.Id,
                    DataFim = projeto.DataFim.GetValueOrDefault()
                };
                return (projetoDB, projetoFinalizadoDB);
            }

            return (projetoDB, null);
        }

        public static EntradaDBModel DomainToDB(Entrada e) => new EntradaDBModel()
        {
            Id = e.Id,
            Material = e.Material,
            Preco = e.Preco,
            Quantidade = e.Quantidade,
            Data = e.Data,
            AlmoxarifadoDestino = e.AlmoxarifadoDestino
        };

        public static SaidaDBModel DomainToDB(Saida e) => new SaidaDBModel()
        {
            Id = e.Id,
            Material = e.Material,
            AlmoxarifadoDestino = e.AlmoxarifadoDestino,
            AlmoxarifadoOrigem = e.AlmoxaridadoOrigem,
            Funcionario = e.Funcionario,
            Quantidade = e.Quantidade,
            Data = e.Data
        };

        public static FuncionarioProjetoDBModel DomainToDB(Funcionario funcionario, Projeto projeto) => new FuncionarioProjetoDBModel()
        {
            FuncionarioId = funcionario.Id,
            ProjetoId = projeto.Id
        };

        public static (AlmoxarifadoDBModel, IList<AlmoxarifadoMaterialDBModel>) DomainToDB (Almoxarifado almoxarifado)
        {
            AlmoxarifadoDBModel almoxarifadoDB = new AlmoxarifadoDBModel () 
            { 
                Id = almoxarifado.Id,
                Nome = almoxarifado.Nome
            };
            List<AlmoxarifadoMaterialDBModel> almoxarifadoMaterialDBs = new List<AlmoxarifadoMaterialDBModel> ();
            foreach (ulong m in almoxarifado.Materiais.Keys)
                almoxarifadoMaterialDBs.Add (new AlmoxarifadoMaterialDBModel ()
                {
                    AlmoxarifadoId = almoxarifado.Id,
                    MaterialId = m,
                    Quantidade = almoxarifado.Materiais[m]
                });

            return (almoxarifadoDB, almoxarifadoMaterialDBs);
        }





        public static Almoxarifado DBToDomain (AlmoxarifadoDBModel almoxarifadoDB, IEnumerable<AlmoxarifadoMaterialDBModel> almoxarifadoMaterialDB) 
        {
            Almoxarifado almoxarifado = DBToDomain (almoxarifadoDB);
            foreach (var am in almoxarifadoMaterialDB)
                almoxarifado.Materiais[am.MaterialId] = am.Quantidade;

            return almoxarifado;
        }

        public static Almoxarifado DBToDomain (AlmoxarifadoDBModel almoxarifadoDB) => new Almoxarifado ()
        {
            Id = almoxarifadoDB.Id,
            Nome = almoxarifadoDB.Nome,
            Materiais = new Dictionary<ulong, decimal>()
        };
        public static Funcionario DBToDomain(FuncionarioDBModel funcionarioDB) => new Funcionario()
        {
            Id = funcionarioDB.Id,
            Nome = funcionarioDB.Nome,
            Cargo = funcionarioDB.Cargo,
            Demitido = funcionarioDB.Demitido
        };

        public static Material DBToDomain(MaterialDBModel materialDB) => new Material()
        {
            Id = materialDB.Id,
            Descricao = materialDB.Descricao,
            Preco = materialDB.Preco,
            Quantidade = materialDB.Quantidade,
            Unidade = materialDB.Unidade
        };

        public static Projeto DBToDomain(ProjetoDBModel projetoDB) => new Projeto()
        {
            Id = projetoDB.Id,
            Nome = projetoDB.Nome,
            DataInicio = projetoDB.DataInicio,
            PrazoEstimado = projetoDB.PrazoEstimado,
            DataFim = null,
            Estado = EstadoProjeto.Andamento,
            AlmoxarifadoId = projetoDB.AlmoxarifadoId
        };

        public static Projeto DBToDomain(ProjetoDBModel projetoDB, ProjetoFinalizadoDBModel projetoFinalizadoDB) 
            => (projetoFinalizadoDB != null && projetoDB.Id == projetoFinalizadoDB.Id) ? new Projeto()
        {
            Id = projetoDB.Id,
            Nome = projetoDB.Nome,
            DataInicio = projetoDB.DataInicio,
            PrazoEstimado = projetoDB.PrazoEstimado,
            DataFim = projetoFinalizadoDB.DataFim,
            Estado = EstadoProjeto.Finalizado,
            AlmoxarifadoId = projetoDB.AlmoxarifadoId
        } : DBToDomain(projetoDB);

        public static Entrada DBToDomain(EntradaDBModel entradaDB) => new Entrada()
        {
            Id = entradaDB.Id,
            Quantidade = entradaDB.Quantidade,
            AlmoxarifadoDestino = entradaDB.AlmoxarifadoDestino,
            Data = entradaDB.Data,
            Material = entradaDB.Material,
            Preco = entradaDB.Preco
        };

        public static Saida DBToDomain(SaidaDBModel saidaDB)=> new Saida()
        {
            Id = saidaDB.Id,
            Data = saidaDB.Data,
            Quantidade = saidaDB.Quantidade,
            AlmoxaridadoOrigem = saidaDB.AlmoxarifadoOrigem,
            AlmoxarifadoDestino = saidaDB.AlmoxarifadoDestino,
            Funcionario = saidaDB.Funcionario,
            Material = saidaDB.Material
        };

    }
}
