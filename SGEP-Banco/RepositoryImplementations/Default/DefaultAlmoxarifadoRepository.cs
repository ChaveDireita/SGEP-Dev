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
    //Completo
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
            AlmoxarifadoDBModel a = _db.Almoxarifado.AsNoTracking().FirstOrDefault(_a => _a.Id == id);
            IEnumerable<AlmoxarifadoMaterialDBModel> am = _db.AlmoxarifadoMaterial.AsNoTracking().Where (_am => _am.AlmoxarifadoId == id);

            return ModelConverter.DBToDomain (a, am);
        }
        
        public IEnumerable<Almoxarifado> GetAll ()
        {
            IEnumerable<Almoxarifado> almoxarifados = _db.Almoxarifado.AsNoTracking ()
                                                                      .ToList ()
                                                                      .ConvertAll(a => ModelConverter.DBToDomain(a));
            foreach (var a in almoxarifados)
                foreach (var am in _db.AlmoxarifadoMaterial.AsNoTracking ().Where (am => am.AlmoxarifadoId == a.Id))
                    a.Materiais[am.MaterialId] = am.Quantidade;

            return almoxarifados;
        }

        public async Task<IEnumerable<Almoxarifado>> GetAllAsync ()
        {
            IEnumerable<Almoxarifado> almoxarifados = (await _db.Almoxarifado.AsNoTracking()
                                                                             .ToListAsync ())
                                                                             .ConvertAll (a => ModelConverter.DBToDomain (a));
            foreach (var a in almoxarifados)
                foreach (var am in _db.AlmoxarifadoMaterial.AsNoTracking()
                                                           .Where (am => am.AlmoxarifadoId == a.Id))
                    a.Materiais[am.MaterialId] = am.Quantidade;

            return almoxarifados;
        }

        public void Remove (Almoxarifado model)
        {
            foreach (var am in _db.AlmoxarifadoMaterial.Where (_am => _am.AlmoxarifadoId == model.Id)) 
            {
                AlmoxarifadoMaterialDBModel dBModel = _db.AlmoxarifadoMaterial.Where (_am => _am.AlmoxarifadoId == 1 && _am.MaterialId == am.MaterialId)
                                                                              .First ();
                if (dBModel == null)
                {
                    dBModel = new AlmoxarifadoMaterialDBModel { AlmoxarifadoId = 1, MaterialId = am.MaterialId, Quantidade = am.Quantidade };
                    _db.Add (dBModel);
                }
                else 
                {
                    dBModel.Quantidade += am.Quantidade;
                    _db.Update (dBModel);
                }
                _db.Remove (am);
            }
            _db.SaveChanges ();
        }

        public void Update (Almoxarifado model)
        {
            (AlmoxarifadoDBModel almoxarifado, IList<AlmoxarifadoMaterialDBModel> mat) a = ModelConverter.DomainToDB (model);

            _db.Almoxarifado.Update (a.almoxarifado);
            if (a.mat.Count > 0)
                foreach (var am in a.mat)
                    if (_db.AlmoxarifadoMaterial.AsNoTracking ()
                                                .Where (_am => _am.MaterialId == am.MaterialId && _am.AlmoxarifadoId == am.AlmoxarifadoId)
                                                .FirstOrDefault () != null)
                        _db.AlmoxarifadoMaterial.Update (am);
                    else
                        _db.AlmoxarifadoMaterial.Add (am);
            _db.SaveChanges ();
        }

        public async Task UpdateAsync (Almoxarifado model)
        {
            (AlmoxarifadoDBModel almoxarifado, IList<AlmoxarifadoMaterialDBModel> mat) a = ModelConverter.DomainToDB (model);

            _db.Update (a.almoxarifado);
            if (a.mat.Count > 0)
                foreach (var am in a.mat)
                    if (await _db.AlmoxarifadoMaterial.AsNoTracking ()
                                                      .Where (_am => _am.MaterialId == am.MaterialId && _am.AlmoxarifadoId == am.AlmoxarifadoId)
                                                      .FirstOrDefaultAsync () != null)
                        _db.AlmoxarifadoMaterial.Update (am);
                    else
                        await _db.AlmoxarifadoMaterial.AddAsync (am);
            await _db.SaveChangesAsync ();
        }
    }
}
