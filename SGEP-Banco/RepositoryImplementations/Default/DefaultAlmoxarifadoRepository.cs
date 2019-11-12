using SGEP_Banco.Contexts;
using SGEP_Banco.Models;
using SGEP_Model.Models;
using SGEP_Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGEP_Banco.RepositoryImplementations.Default
{
    public class DefaultAlmoxarifadoRepository : IAlmoxarifadoRepository
    {
        private DefaultContext _db;
        public DefaultAlmoxarifadoRepository (DefaultContext db) => _db = db;

        public void Add (Almoxarifado model)
        {
            (AlmoxarifadoDBModel almoxarifado, IList<AlmoxarifadoMaterialDBModel> mat) a = ModelConverter.DomainToDB (model);

            _db.Almoxarifado.Add (a.almoxarifado);
            if (a.mat.Count > 0)
                foreach (var am in a.mat)
                    _db.AlmoxarifadoMaterial.Add (am);
            _db.SaveChanges ();
        }

        public async Task AddAsync (Almoxarifado model)
        {
            (AlmoxarifadoDBModel almoxarifado, IList<AlmoxarifadoMaterialDBModel> mat) a = ModelConverter.DomainToDB (model);

            await _db.Almoxarifado.AddAsync (a.almoxarifado);
            if (a.mat.Count > 0)
                foreach (var am in a.mat)
                    await _db.AlmoxarifadoMaterial.AddAsync (am);
            await _db.SaveChangesAsync ();
        }

        public Almoxarifado Get (ulong id) => ModelConverter.DBToDomain (_db.Almoxarifado.Find (id), _db.AlmoxarifadoMaterial.Where (am => am.AlmoxarifadoId == id));
        

        public IEnumerable<Almoxarifado> GetAll ()
        {
            throw new NotImplementedException ();
        }

        public Task<IEnumerable<Almoxarifado>> GetAllAsync ()
        {
            throw new NotImplementedException ();
        }

        public void Update (Almoxarifado model)
        {
            (AlmoxarifadoDBModel almoxarifado, IList<AlmoxarifadoMaterialDBModel> mat) a = ModelConverter.DomainToDB (model);

            _db.Almoxarifado.Update (a.almoxarifado);
            if (a.mat.Count > 0)
                foreach (var am in a.mat)
                    _db.AlmoxarifadoMaterial.Update (am);
            _db.SaveChanges ();
        }

        public async Task UpdateAsync (Almoxarifado model)
        {
            (AlmoxarifadoDBModel almoxarifado, IList<AlmoxarifadoMaterialDBModel> mat) a = ModelConverter.DomainToDB (model);

            _db.Almoxarifado.Update (a.almoxarifado);
            if (a.mat.Count > 0)
                foreach (var am in a.mat)
                    _db.AlmoxarifadoMaterial.Update (am);
            await _db.SaveChangesAsync ();
        }
    }
}
