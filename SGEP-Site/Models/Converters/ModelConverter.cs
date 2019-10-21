using SGEP_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public sealed class ModelConverter
    {
        private ModelConverter() { }

        public static FuncionarioViewModel DomainToView(Funcionario funcionario) => new FuncionarioViewModel()
        {
            Id = funcionario.Id,
            Nome = funcionario.Nome,
            Cargo = funcionario.Cargo,
            Demitido = funcionario.Demitido
        };

        public static MaterialViewModel DomainToView(Material material) => new MaterialViewModel()
        {
            Id = material.Id,
            Descricao = material.Descricao,
            Preco = material.Preco,
            Quantidade = material.Quantidade,
            Unidade = material.Unidade
        };

        public static ProjetoViewModel DomainToView(Projeto projeto) => new ProjetoViewModel()
        {
            Id = projeto.Id,
            Nome = projeto.Nome,
            DataInicio = projeto.DataInicio,
            PrazoEstimado = projeto.PrazoEstimado,
            DataFim = projeto.DataFim,
            Estado = nameof(projeto.Estado)
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entrada"></param>
        /// <param name="inutil">Necessário para diferenciar a assinatura deste método da criação do tipo especializado da movimentação</param>
        /// <returns></returns>
        public static MovimentacaoViewModel DomainToView(Entrada entrada, bool inutil) => new MovimentacaoViewModel()
        {
            Id = entrada.Id,
            Data = entrada.Data,
            MaterialMovimentado = entrada.MaterialMovimentado.Descricao,
            Quantidade = entrada.Quantidade,
            TipoMovimentacao = entrada.TipoMovimentacao
        };

        public static MovimentacaoViewModel DomainToView(Saida s, bool inutil) => new MovimentacaoViewModel()
        {
            Id = s.Id,
            Data = s.Data,
            MaterialMovimentado = s.MaterialMovimentado.Descricao,
            Quantidade = s.Quantidade,
            TipoMovimentacao = s.TipoMovimentacao
        };







        public static Funcionario ViewToDomain(FuncionarioViewModel funcionario) => new Funcionario()
        {
            Id = funcionario.Id,
            Nome = funcionario.Nome,
            Cargo = funcionario.Cargo,
            Demitido = funcionario.Demitido
        };

        public static Material ViewToDomain(MaterialViewModel m) => new Material()
        {
            Id = m.Id,
            Descricao = m.Descricao,
            Preco = m.Preco,
            Quantidade = m.Quantidade,
            Unidade = m.Unidade
        };

    }
}
