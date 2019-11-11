using SGEP_Model.Models;
using SGEP_Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Views
{
    public class CreateEntradaService
    {
        private IMaterialRepository _repoMat;
        private IAlmoxarifadoRepository _repoAlm;

        public CreateEntradaService (IMaterialRepository repoMat, IAlmoxarifadoRepository repoAlm)
        {
            _repoMat = repoMat;
            _repoAlm = repoAlm;
        }

        public async Task<IEnumerable<Material>> GetMateriais () => await _repoMat.GetAllAsync ();
        public async Task<IEnumerable<Almoxarifado>> GetAlmoxarifados () => await _repoAlm.GetAllAsync ();
        //public async Task<IEnumerable<Projeto>> GetProjetos () await
    }
}
