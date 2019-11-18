using Microsoft.EntityFrameworkCore;
using SGEP_Banco.Contexts;
using SGEP_Banco.Models;
using SGEP_Model.Models;
using SGEP_Services.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Banco.RepositoryImplementations
{
    public class DefaultEntradaRepository : IEntradaRepository
    {
        private readonly DefaultContext _db;
        public DefaultEntradaRepository(DefaultContext db) => _db = db;
        public void Add(Entrada entrada)
        {
            _db.Add(ModelConverter.DomainToDB(entrada));
            _db.SaveChanges();
        }

        public async Task AddAsync(Entrada entrada)
        {
            _db.Add(ModelConverter.DomainToDB(entrada));
            await _db.SaveChangesAsync();
        }

        public Entrada Get(ulong id)
        {
            EntradaDBModel entradaDB = _db.Entrada.Find(id);
            return ModelConverter.DBToDomain(entradaDB);
        }

        public IEnumerable<Entrada> GetAll()
        { 
            List<EntradaDBModel> entradaDBs = _db.Entrada.ToList();

            return entradaDBs.ConvertAll(e => ModelConverter.DBToDomain(e));
        }

        public async Task<IEnumerable<Entrada>> GetAllAsync()
        {
            List<EntradaDBModel> entradaDBs = await _db.Entrada.ToListAsync();

            return entradaDBs.ConvertAll(e => ModelConverter.DBToDomain(e));
        }

        public void Update(Entrada entrada)
        {
            _db.Update(ModelConverter.DomainToDB(entrada));
            _db.SaveChanges();
        }

        public async Task UpdateAsync(Entrada entrada)
        {
            _db.Update(ModelConverter.DomainToDB(entrada));
            await _db.SaveChangesAsync();
        }
    }
}
