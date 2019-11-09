using SGEP_Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGEP_Services.Repository
{
    public interface IProjetoRepository : IRepository<Projeto>
    {
        IEnumerable<Funcionario> GetFuncionarios(ulong id);
        Task<IEnumerable<Funcionario>> GetFuncionariosAsync(ulong id);
        IEnumerable<Funcionario> GetFuncionariosFora(ulong id);
        Task<IEnumerable<Funcionario>> GetFuncionariosForaAsync(ulong id);
        void AddFuncionario(Projeto projeto, Funcionario funcionario);
        Task AddFuncionarioAsync(Projeto projeto, Funcionario funcionario);
        Task RemoveFuncionario (ulong pid, ulong fid);
        Task RemoveFuncionarios (ulong pid);
    }
}
