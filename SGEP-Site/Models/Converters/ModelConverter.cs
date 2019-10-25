using SGEP_Model.Models;

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
            Demitido = (funcionario.Demitido) ? "Sim" : "Não"
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
        /// <param name="action">Necessário para diferenciar a assinatura deste método da criação do tipo especializado da movimentação</param>
        /// <returns></returns>
        public static MovimentacaoViewModel DomainToView(Entrada entrada, string action) => new MovimentacaoViewModel()
        {
            Id = entrada.Id,
            Data = entrada.Data,
            MaterialMovimentado = entrada.MaterialMovimentado.Descricao,
            Quantidade = entrada.Quantidade,
            TipoMovimentacao = entrada.TipoMovimentacao,
            Action = action
        };

        public static MovimentacaoViewModel DomainToView(Saida saida, string action) => new MovimentacaoViewModel()
        {
            Id = saida.Id,
            Data = saida.Data,
            MaterialMovimentado = saida.MaterialMovimentado.Descricao,
            Quantidade = saida.Quantidade,
            TipoMovimentacao = saida.TipoMovimentacao,
            Action = action
        };







        public static Funcionario ViewToDomain(FuncionarioViewModel funcionario) => new Funcionario()
        {
            Id = funcionario.Id,
            Nome = funcionario.Nome,
            Cargo = funcionario.Cargo,
            Demitido = (funcionario.Demitido.ToLower() == "sim") ? true : false
        };

        public static Funcionario ViewToDomain(FuncionarioCreateViewModel funcionario) => new Funcionario()
        {
            Nome = funcionario.Nome,
            Cargo = funcionario.Cargo,
            Demitido = false
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
