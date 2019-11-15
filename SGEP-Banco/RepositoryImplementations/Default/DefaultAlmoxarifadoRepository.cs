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
    public class DefaultAlmoxarifadoRepository : IAlmoxarifadoRepository
    {
        private DefaultContext _db;
        public DefaultAlmoxarifadoRepository (DefaultContext db) => _db = db;

        public void Add (Almoxarifado model)
        {
            (AlmoxarifadoDBModel a, IList<AlmoxarifadoMaterialDBModel> am) = ModelConverter.DomainToDB (model);

            _db.Almoxarifado.Add (a);
            foreach (var i in am)
                _db.AlmoxarifadoMaterial.Add (i);

            _db.SaveChanges ();
        }

        public async Task AddAsync (Almoxarifado model)
        {
            (AlmoxarifadoDBModel a, IList<AlmoxarifadoMaterialDBModel> am) = ModelConverter.DomainToDB (model);

            _db.Almoxarifado.Add (a);
            foreach (var i in am)
                _db.AlmoxarifadoMaterial.Add (i);

            await _db.SaveChangesAsync ();
        }

        public Almoxarifado Get (ulong id)
        {
            AlmoxarifadoDBModel a = _db.Almoxarifado.Find (id);
            IEnumerable<AlmoxarifadoMaterialDBModel> am = _db.AlmoxarifadoMaterial.Where (_am => _am.AlmoxarifadoId == id);

            return ModelConverter.DBToDomain (a, am);
        }

        public IEnumerable<Almoxarifado> GetAll ()
        {
            IEnumerable<Almoxarifado> almoxarifados = _db.Almoxarifado.ToList ()
                                                                      .ConvertAll(a => ModelConverter.DBToDomain(a));
            foreach (var a in almoxarifados)
                a.Materiais = new Dictionary<ulong, decimal> ();

            return almoxarifados;
        }

        public async Task<IEnumerable<Almoxarifado>> GetAllAsync ()
        {
            IEnumerable<Almoxarifado> almoxarifados = (await _db.Almoxarifado.ToListAsync ())
                                                                             .ConvertAll (a => ModelConverter.DBToDomain (a));
            foreach (var a in almoxarifados)
                a.Materiais = new Dictionary<ulong, decimal> ();

            return almoxarifados;
        }

        public void Update (Almoxarifado model)
        {
            _db.Update (model);
            _db.SaveChanges ();
        }

        public async Task UpdateAsync (Almoxarifado model)
        {
            _db.Update (model);
            await _db.SaveChangesAsync ();
        }
    }
}
