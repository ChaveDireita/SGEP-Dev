using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGEP_Banco.Contexts;
using SGEP_Banco.Models;
using SGEP_Model.Models;
using SGEP_Services.Repository;

namespace SGEP_Banco.RepositoryImplementations
{
    public class DefaultProjetoRepository : IProjetoRepository
    {

        private readonly DefaultContext _db;
        public DefaultProjetoRepository(DefaultContext db) => _db = db;

        public void Add(Projeto projeto)
        {
            (ProjetoDBModel pDB, ProjetoFinalizadoDBModel pfDB) projetoDB = ModelConverter.DomainToDB(projeto);
            _db.Add(projetoDB.pDB);
            if (projetoDB.pfDB != null)
                _db.Add(projetoDB.pfDB);
            _db.SaveChanges();
        }

        public async Task AddAsync(Projeto projeto)
        {
            (ProjetoDBModel pDB, ProjetoFinalizadoDBModel pfDB) projetoDB = ModelConverter.DomainToDB(projeto);
            _db.Add(projetoDB.pDB);
            if (projetoDB.pfDB != null)
                _db.Add(projetoDB.pfDB);
            await _db.SaveChangesAsync();
        }

        public void AddFuncionario(Projeto projeto, Funcionario funcionario)
        {
            FuncionarioProjetoDBModel funcionarioProjeto = ModelConverter.DomainToDB(funcionario, projeto);
            _db.Add(funcionarioProjeto);
            _db.SaveChanges();
        }

        public async Task AddFuncionarioAsync(Projeto projeto, Funcionario funcionario)
        {
            FuncionarioProjetoDBModel funcionarioProjeto = ModelConverter.DomainToDB(funcionario, projeto);
            _db.Add(funcionarioProjeto);
            await _db.SaveChangesAsync();
        }

        public Projeto Get(ulong id) => ModelConverter.DBToDomain(_db.Projeto.Find(id), _db.ProjetoFinalizado.Find(id));

        public IEnumerable<Projeto> GetAll() 
        {
            IEnumerable<Projeto> projetos = (from p in _db.Projeto
                                             from pf in _db.ProjetoFinalizado
                                             where p.Id == pf.Id
                                             select ModelConverter.DBToDomain(p, pf))
                                             .Distinct();
            IEnumerable<Projeto> aux = (from p in _db.Projeto
                                        from pf in _db.ProjetoFinalizado
                                        where p.Id != pf.Id
                                        select ModelConverter.DBToDomain(p, pf))
                                        .Distinct();
            foreach (Projeto p in aux)
                projetos.Append(p);

            return projetos;
        }

        public async Task<IEnumerable<Projeto>> GetAllAsync()
        {
            IList<ProjetoDBModel> projetoDBs = await _db.Projeto.ToListAsync();
            IList<ProjetoFinalizadoDBModel> projetoFinalizadoDBs = await _db.ProjetoFinalizado.ToListAsync();

            IEnumerable<Projeto> projetos = (from p in projetoDBs
                                             from pf in projetoFinalizadoDBs
                                             where p.Id == pf.Id
                                             select ModelConverter.DBToDomain(p, pf))
                                             .Distinct();
            IEnumerable<Projeto> aux = (from p in projetoDBs
                                        from pf in projetoFinalizadoDBs
                                        where p.Id != pf.Id
                                        select ModelConverter.DBToDomain(p, pf))
                                        .Distinct();
            foreach (Projeto p in aux)
                projetos.Append(p);

            return projetos;
        }

        public IEnumerable<Funcionario> GetFuncionarios(ulong id)
        {
            IEnumerable<FuncionarioProjetoDBModel> funcionarioProjetos = _db.FuncionarioProjeto.ToList().Where(fp => fp.ProjetoId == id);
            IList<Funcionario> funcionarios = new List<Funcionario>();

            foreach (FuncionarioProjetoDBModel fp in funcionarioProjetos)
                funcionarios.Add(ModelConverter.DBToDomain(_db.Funcionario.Find(fp.FuncionarioId)));

            return funcionarios;
        }

        public async Task<IEnumerable<Funcionario>> GetFuncionariosAsync(ulong id)
        {
            IEnumerable<FuncionarioProjetoDBModel> funcionarioProjetos = (await _db.FuncionarioProjeto.ToListAsync()).Where(fp => fp.ProjetoId == id);
            IList<Funcionario> funcionarios = new List<Funcionario>();

            foreach (FuncionarioProjetoDBModel fp in funcionarioProjetos)
                funcionarios.Add(ModelConverter.DBToDomain(await _db.Funcionario.FindAsync(fp.FuncionarioId)));

            return funcionarios;
        }

        public IEnumerable<Funcionario> GetFuncionariosFora(ulong id)
        {
            IEnumerable<FuncionarioProjetoDBModel> funcionarioProjetos = _db.FuncionarioProjeto.ToList().Where(fp => fp.ProjetoId != id);
            IList<Funcionario> funcionarios = new List<Funcionario>();

            foreach (FuncionarioProjetoDBModel fp in funcionarioProjetos)
                funcionarios.Add(ModelConverter.DBToDomain(_db.Funcionario.Find(fp.FuncionarioId)));

            return funcionarios;
        }

        public async Task<IEnumerable<Funcionario>> GetFuncionariosForaAsync(ulong id)
        {
            IEnumerable<FuncionarioProjetoDBModel> funcionarioProjetos = (await _db.FuncionarioProjeto.ToListAsync()).Where(fp => fp.ProjetoId != id);
            IList<Funcionario> funcionarios = new List<Funcionario>();

            foreach (FuncionarioProjetoDBModel fp in funcionarioProjetos)
                funcionarios.Add(ModelConverter.DBToDomain(await _db.Funcionario.FindAsync(fp.FuncionarioId)));

            return funcionarios;
        }

        public void Update(Projeto projeto)
        {
            (ProjetoDBModel pDB, ProjetoFinalizadoDBModel pfDB) projetoDB = ModelConverter.DomainToDB(projeto);
            _db.Update(projetoDB.pDB);
            if (projetoDB.pfDB != null)
                _db.Update(projetoDB.pfDB);
            _db.SaveChanges();
        }

        public async Task UpdateAsync(Projeto projeto)
        {
            (ProjetoDBModel pDB, ProjetoFinalizadoDBModel pfDB) projetoDB = ModelConverter.DomainToDB(projeto);
            _db.Update(projetoDB.pDB);
            if (projetoDB.pfDB != null)
                _db.Update(projetoDB.pfDB);
            await _db.SaveChangesAsync();
        }
    }
}
