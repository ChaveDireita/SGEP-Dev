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
            MaterialDBModel materialDB = _db.Material.Find(entradaDB.Id);
            return ModelConverter.DBToDomain(entradaDB, materialDB);
        }

        public IEnumerable<Entrada> GetAll()
        {
            IList<Entrada> entradas = new List<Entrada>();
            IList<EntradaDBModel> entradaDBs = _db.Entrada.ToList();

            foreach (EntradaDBModel e in entradaDBs)
                entradas.Add(ModelConverter.DBToDomain(e, _db.Material.Find(e.MaterialID)));

            return entradas;
        }

        public async Task<IEnumerable<Entrada>> GetAllAsync()
        {
            IList<Entrada> entradas = new List<Entrada>();
            IList<EntradaDBModel> entradaDBs = await _db.Entrada.ToListAsync();

            foreach (EntradaDBModel e in entradaDBs)
                entradas.Add(ModelConverter.DBToDomain(e, await _db.Material.FindAsync(e.MaterialID)));

            return entradas;
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
