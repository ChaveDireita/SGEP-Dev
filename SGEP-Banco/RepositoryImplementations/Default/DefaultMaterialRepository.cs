using Microsoft.EntityFrameworkCore;
using SGEP_Banco.Contexts;
using SGEP_Banco.Models;
using SGEP_Model.Models;
using SGEP_Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGEP_Banco.RepositoryImplementations
{
    public class DefaultMaterialRepository : IMaterialRepository
    {
        private readonly DefaultContext _db;
        public DefaultMaterialRepository(DefaultContext db) => _db = db;
        public void Add(Material material)
        {
            _db.Add(ModelConverter.DomainToDB(material));
            _db.SaveChanges();
        }

        public async Task AddAsync(Material material)
        {
            _db.Add(ModelConverter.DomainToDB(material));
            await _db.SaveChangesAsync();
        }

        public Material Get(ulong id) => ModelConverter.DBToDomain(_db.Material.Find(id));

        public IEnumerable<Material> GetAll() => _db.Material.ToList().ConvertAll(mdb => ModelConverter.DBToDomain(mdb));

        public async Task<IEnumerable<Material>> GetAllAsync()
        {
            Task<List<MaterialDBModel>> materialDBs = _db.Material.ToListAsync();
            return (await materialDBs).ConvertAll(mdb => ModelConverter.DBToDomain(mdb));
        }

        public void Update(Material material)
        {
            _db.Update(ModelConverter.DomainToDB(material));
            _db.SaveChanges();
        }

        public async Task UpdateAsync(Material material)
        {
            _db.Update(ModelConverter.DomainToDB(material));
            await _db.SaveChangesAsync();
        }
    }
}
