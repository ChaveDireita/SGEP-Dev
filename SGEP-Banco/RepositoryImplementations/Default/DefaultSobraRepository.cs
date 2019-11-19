using Microsoft.EntityFrameworkCore;
using SGEP_Banco.Contexts;
using SGEP_Banco.Models;
using SGEP_Model.Models;
using SGEP_Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Banco.RepositoryImplementations
{
    public class DefaultSobraRepository : ISobraRepository
    {
        private readonly DefaultContext _db;

        public DefaultSobraRepository (DefaultContext db) => _db = db;

        public void Add (Sobra model)
        {
            _db.Add (ModelConverter.DomainToDB(model));
            _db.SaveChanges ();
        }

        public async Task AddAsync (Sobra model)
        {
            _db.Add (ModelConverter.DomainToDB(model));
            await _db.SaveChangesAsync ();
        }

        public Sobra Get (ulong id) => ModelConverter.DBToDomain (_db.Sobra.Find (id));

        public IEnumerable<Sobra> GetAll () => _db.Sobra.ToList ().ConvertAll(s => ModelConverter.DBToDomain(s));

        public async Task<IEnumerable<Sobra>> GetAllAsync () => (await _db.Sobra.ToListAsync ()).ConvertAll (s => ModelConverter.DBToDomain (s));

        public void Update (Sobra model)
        {
            throw new NotImplementedException ();
        }

        public Task UpdateAsync (Sobra model)
        {
            throw new NotImplementedException ();
        }
    }
}
