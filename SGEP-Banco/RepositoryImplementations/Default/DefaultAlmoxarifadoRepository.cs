using SGEP_Banco.Contexts;
using SGEP_Model.Models;
using SGEP_Services.Repository;
using System;
using System.Collections.Generic;
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
            //_db.Almoxarifado.Add ();
        }

        public Task AddAsync (Almoxarifado model)
        {
            throw new NotImplementedException ();
        }

        public Almoxarifado Get (ulong id)
        {
            throw new NotImplementedException ();
        }

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
            throw new NotImplementedException ();
        }

        public Task UpdateAsync (Almoxarifado model)
        {
            throw new NotImplementedException ();
        }
    }
}
