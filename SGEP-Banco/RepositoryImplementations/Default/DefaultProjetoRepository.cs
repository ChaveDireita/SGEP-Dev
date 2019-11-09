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
        public DefaultProjetoRepository (DefaultContext db) => _db = db;

        public void Add (Projeto projeto)
        {
            (ProjetoDBModel pDB, ProjetoFinalizadoDBModel pfDB) projetoDB = ModelConverter.DomainToDB (projeto);
            _db.Add (projetoDB.pDB);
            if (projetoDB.pfDB != null)
                _db.Add (projetoDB.pfDB);
            _db.SaveChanges ();
        }

        public async Task AddAsync (Projeto projeto)
        {
            (ProjetoDBModel pDB, ProjetoFinalizadoDBModel pfDB) projetoDB = ModelConverter.DomainToDB (projeto);
            _db.Add (projetoDB.pDB);
            if (projetoDB.pfDB != null)
                _db.Add (projetoDB.pfDB);
            await _db.SaveChangesAsync ();
        }

        public void AddFuncionario (Projeto projeto, Funcionario funcionario)
        {
            FuncionarioProjetoDBModel funcionarioProjeto = ModelConverter.DomainToDB (funcionario, projeto);
            _db.Add (funcionarioProjeto);
            _db.SaveChanges ();
        }

        public async Task AddFuncionarioAsync (Projeto projeto, Funcionario funcionario)
        {
            FuncionarioProjetoDBModel funcionarioProjeto = ModelConverter.DomainToDB (funcionario, projeto);
            _db.Add (funcionarioProjeto);
            await _db.SaveChangesAsync ();
        }

        public async Task RemoveFuncionario (ulong pid, ulong fid)
        {
            _db.Remove (_db.FuncionarioProjeto.Find (fid, pid));
            await _db.SaveChangesAsync ();
        }

        public async Task RemoveFuncionarios (ulong pid)
        {
            foreach(var fp in _db.FuncionarioProjeto.Where (fp => fp.ProjetoId == pid))
                _db.Remove(fp);
            await _db.SaveChangesAsync ();
        }

        public Projeto Get(ulong id) => ModelConverter.DBToDomain(_db.Projeto.Find(id), _db.ProjetoFinalizado.Find(id));

        public IEnumerable<Projeto> GetAll() 
        {
            List<ProjetoDBModel> projetoDBs = _db.Projeto.ToList ();
            List<ProjetoFinalizadoDBModel> projetoFinalizadoDBs = _db.ProjetoFinalizado.ToList ();

            List<Projeto> projetos = (from p in projetoDBs
                                      from pf in projetoFinalizadoDBs
                                      where p.Id == pf.Id
                                      select ModelConverter.DBToDomain (p, pf))
                                     .Distinct ()
                                     .ToList ();

            projetoDBs = projetoDBs.Where (pdb => !projetoFinalizadoDBs.ConvertAll (pf => pf.Id)
                                                                       .Contains (pdb.Id))
                                                                       .ToList ();

            IEnumerable<Projeto> aux = from p in projetoDBs
                                       select ModelConverter.DBToDomain (p);

            foreach (Projeto p in aux)
                projetos.Add (p);

            return projetos;
        }

        public async Task<IEnumerable<Projeto>> GetAllAsync()
        {
            List<ProjetoDBModel> projetoDBs = await _db.Projeto.ToListAsync();
            List<ProjetoFinalizadoDBModel> projetoFinalizadoDBs = await _db.ProjetoFinalizado.ToListAsync();

            List<Projeto> projetos = (from p in projetoDBs
                                     from pf in projetoFinalizadoDBs
                                     where p.Id == pf.Id
                                     select ModelConverter.DBToDomain(p, pf))
                                     .Distinct()
                                     .ToList();

            projetoDBs = projetoDBs.Where (pdb => !projetoFinalizadoDBs.ConvertAll (pf => pf.Id)
                                                                       .Contains (pdb.Id))
                                                                       .ToList();

            IEnumerable<Projeto> aux = from p in projetoDBs
                                       select ModelConverter.DBToDomain (p);

            foreach (Projeto p in aux)
                projetos.Add(p);

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
            IEnumerable<ulong> funcionariosIds = _db.Funcionario.ToList()
                                                                .ConvertAll(f => f.Id)
                                                                .Except(_db.FuncionarioProjeto.Where (fp => fp.ProjetoId == id)
                                                                                              .ToList()
                                                                                              .ConvertAll(fp => fp.FuncionarioId));

//            foreach (FuncionarioProjetoDBModel fp in funcionarioProjetos)
//                funcionarios.Add(ModelConverter.DBToDomain(_db.Funcionario.Find(fp.FuncionarioId)));

            return funcionariosIds.ToList().ConvertAll(fid => ModelConverter.DBToDomain (_db.Funcionario.Find(fid)));
        }

        public async Task<IEnumerable<Funcionario>> GetFuncionariosForaAsync(ulong id)
        {
            IEnumerable<ulong> funcionariosIds = (await _db.Funcionario.ToListAsync ())
                                                                       .ConvertAll (f => f.Id)
                                                                       .Except ((await _db.FuncionarioProjeto.Where (fp => fp.ProjetoId == id)
                                                                                                             .ToListAsync ())
                                                                                                             .ConvertAll (fp => fp.FuncionarioId));

            return funcionariosIds.ToList ().ConvertAll (fid => ModelConverter.DBToDomain (_db.Funcionario.Find (fid)));
        }

        public void Update(Projeto projeto)
        {
            (ProjetoDBModel pDB, ProjetoFinalizadoDBModel pfDB) projetoDB = ModelConverter.DomainToDB(projeto);
            _db.Update(projetoDB.pDB);
            if (projetoDB.pfDB != null)
                if (_db.ProjetoFinalizado.Any(pf => pf.Id == projetoDB.pfDB.Id))
                    _db.Update (projetoDB.pfDB);
                else
                    _db.Add (projetoDB.pfDB);
            _db.SaveChanges();
        }

        public async Task UpdateAsync(Projeto projeto)
        {
            (ProjetoDBModel pDB, ProjetoFinalizadoDBModel pfDB) projetoDB = ModelConverter.DomainToDB(projeto);
            _db.Update(projetoDB.pDB);
            if (projetoDB.pfDB != null)
                if (await _db.ProjetoFinalizado.AnyAsync (pf => pf.Id == projetoDB.pfDB.Id))
                    _db.Update (projetoDB.pfDB);
                else
                    await _db.AddAsync (projetoDB.pfDB);
            await _db.SaveChangesAsync();
        }
    }
}
