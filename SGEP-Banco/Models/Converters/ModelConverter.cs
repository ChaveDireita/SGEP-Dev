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
            ProjetoDBModel projetoDB = new ProjetoDBModel()
            {
                Id = projeto.Id,
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
            MaterialID = e.MaterialMovimentado.Id,
            Preco = e.Preco,
            Quantidade = e.Quantidade,
            Data = e.Data
        };

        public static SaidaDBModel DomainToDB(Saida e) => new SaidaDBModel()
        {
            Id = e.Id,
            MaterialID = e.MaterialMovimentado.Id,
            ProjetoID = e.ProjetoSolicitante.Id,
            FuncionarioID = e.Solicitante.Id,
            Quantidade = e.Quantidade,
            Data = e.Data
        };

        public static FuncionarioProjetoDBModel DomainToDB(Funcionario funcionario, Projeto projeto) => new FuncionarioProjetoDBModel()
        {
            FuncionarioId = funcionario.Id,
            ProjetoId = projeto.Id
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
            Estado = EstadoProjeto.Andamento
        };

        public static Projeto DBToDomain(ProjetoDBModel projetoDB, ProjetoFinalizadoDBModel projetoFinalizadoDB) 
            => (projetoFinalizadoDB != null && projetoDB.Id == projetoFinalizadoDB.Id) ? new Projeto()
        {
            Id = projetoDB.Id,
            Nome = projetoDB.Nome,
            DataInicio = projetoDB.DataInicio,
            PrazoEstimado = projetoDB.PrazoEstimado,
            DataFim = projetoFinalizadoDB.DataFim,
            Estado = EstadoProjeto.Finalizado
        } : DBToDomain(projetoDB);

        public static Entrada DBToDomain(EntradaDBModel entradaDB, MaterialDBModel materialDB) 
            => (entradaDB.MaterialID == materialDB.Id) ? new Entrada()
        {
            Id = entradaDB.Id,
            MaterialMovimentado = DBToDomain(materialDB),
            Preco = entradaDB.Preco,
            Quantidade = entradaDB.Quantidade
        } : null;

        public static Saida DBToDomain(SaidaDBModel saidaDB, FuncionarioDBModel funcionarioDB, MaterialDBModel materialDB, ProjetoDBModel projetoDB)
            => (saidaDB.MaterialID == materialDB.Id && 
                saidaDB.ProjetoID == projetoDB.Id &&
                saidaDB.FuncionarioID == funcionarioDB.Id) ? new Saida()
            {
                Id = saidaDB.Id,
                MaterialMovimentado = DBToDomain(materialDB),
                ProjetoSolicitante = DBToDomain(projetoDB),
                Solicitante = DBToDomain(funcionarioDB),
                Data = saidaDB.Data,
                Quantidade = saidaDB.Quantidade
            } : null;

        public static Saida DBToDomain(SaidaDBModel saidaDB, FuncionarioDBModel funcionarioDB, MaterialDBModel materialDB, ProjetoDBModel projetoDB, ProjetoFinalizadoDBModel projetoFinalizadoDB)
            => (saidaDB.MaterialID == materialDB.Id &&
                saidaDB.ProjetoID == projetoDB.Id &&
                saidaDB.FuncionarioID == funcionarioDB.Id &&
                projetoDB.Id == projetoFinalizadoDB.Id) ? new Saida()
                {
                    Id = saidaDB.Id,
                    MaterialMovimentado = DBToDomain(materialDB),
                    ProjetoSolicitante = DBToDomain(projetoDB, projetoFinalizadoDB),
                    Solicitante = DBToDomain(funcionarioDB),
                    Data = saidaDB.Data,
                    Quantidade = saidaDB.Quantidade
                } : null;
    }
}
