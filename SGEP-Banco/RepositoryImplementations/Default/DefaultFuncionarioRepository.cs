using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using SGEP_Model.Models;
using SGEP_Services.Repository;
using SGEP_Banco.Contexts;
using SGEP_Banco.Models;

using Microsoft.EntityFrameworkCore;

namespace SGEP_Banco.RepositoryImplementations
{
    public class DefaultFuncionarioRepository : IFuncionarioRepository
    {
        private readonly DefaultContext _db;
        public DefaultFuncionarioRepository(DefaultContext db) => _db = db;

        public void Add(Funcionario funcionario)
        {
            _db.Add(ModelConverter.DomainToDB(funcionario));
            _db.SaveChanges();
        }

        public async Task AddAsync(Funcionario funcionario)
        {
            _db.Add(ModelConverter.DomainToDB(funcionario));
            await _db.SaveChangesAsync();
        }

        public Funcionario Get(ulong id) => ModelConverter.DBToDomain (_db.Funcionario.Find(id));

        public IEnumerable<Funcionario> GetAll() => _db.Funcionario.ToList().ConvertAll(fdb => ModelConverter.DBToDomain(fdb));

        public async Task<IEnumerable<Funcionario>> GetAllAsync() 
        {
            Task<List<FuncionarioDBModel>> funcionarioDBs = _db.Funcionario.ToListAsync();
            return (await funcionarioDBs).ConvertAll(fdb => ModelConverter.DBToDomain(fdb));
        }

        public IEnumerable<Funcionario> GetContratados() => _db.Funcionario.ToList().ConvertAll(fdb => ModelConverter.DBToDomain(fdb))
                                                                                    .Where(fdb => !fdb.Demitido);
        

        public async Task<IEnumerable<Funcionario>> GetContratadosAsync() => (await _db.Funcionario.ToListAsync()).ConvertAll(fdb => ModelConverter.DBToDomain(fdb))
                                                                                                                  .Where(fdb => !fdb.Demitido);

        public void Update(Funcionario funcionario)
        {
            _db.Update(ModelConverter.DomainToDB(funcionario));
            _db.SaveChanges();
        }

        public async Task UpdateAsync(Funcionario funcionario)
        {
            _db.Update(ModelConverter.DomainToDB(funcionario));
            await _db.SaveChangesAsync();
        }

        public void Demitir (ulong id)
        {
            _db.Funcionario.FromSql ($"UPDATE demitido=true FROM funcionario WHERE id={id}");
        }
    }
}
