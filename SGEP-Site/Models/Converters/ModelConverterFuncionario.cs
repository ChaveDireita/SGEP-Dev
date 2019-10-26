using SGEP_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public partial class ModelConverterFuncionario
    {
        public static FuncionarioIndexViewModel DomainToIndexView (Funcionario funcionario) => new FuncionarioIndexViewModel ()
        {
            Id = funcionario.Id,
            Nome = funcionario.Nome,
            Cargo = funcionario.Cargo,
            Demitido = (funcionario.Demitido) ? "Sim" : "Não"
        };

        public static FuncionarioEditViewModel DomainToEditView (Funcionario funcionario) => new FuncionarioEditViewModel ()
        {
            Id = funcionario.Id,
            Nome = funcionario.Nome,
            Cargo = funcionario.Cargo,
            Demitido = (funcionario.Demitido) ? "Demitido" : ""
        };

        public static FuncionarioDetailsViewModel DomainToDetailsView (Funcionario funcionario, IEnumerable<ProjetoViewModel> projetos) => new FuncionarioDetailsViewModel ()
        {
            Id = funcionario.Id,
            Nome = funcionario.Nome,
            Cargo = funcionario.Cargo,
            Demitido = (funcionario.Demitido) ? "Demitido" : "",
            Projetos = projetos
        };













        public static Funcionario ViewToDomain (FuncionarioCreateViewModel funcionario) => new Funcionario ()
        {
            Nome = funcionario.Nome,
            Cargo = funcionario.Cargo,
            Demitido = false
        };
    }
}
