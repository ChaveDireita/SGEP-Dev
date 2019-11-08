using SGEP_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models {
    public class AlmoxarifadoViewModel {
        public ulong Id { get; set; }
        public string Nome { get; set; }
        public ulong? IdProj { get; set; }
        public IEnumerable<Material> MateriaisAssociados { get; set; }
        public Dictionary<int, decimal> RelacaoMaterialQuantidade;
    }
}
