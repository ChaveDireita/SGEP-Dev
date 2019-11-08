using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SGEP_Model.Models;

namespace SGEP_Services.Repository
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        IEnumerable<Funcionario> GetContratados/*i.e. Demitido = false*/();
        Task<IEnumerable<Funcionario>> GetContratadosAsync();
        IEnumerable<Projeto> GetProjetos(ulong id);
        Task<IEnumerable<Projeto>> GetProjetosAsync(ulong id);
        void Deletar (ulong id);
    }
}
