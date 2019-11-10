using System;
using System.Collections.Generic;
using System.Text;

namespace SGEP_Model.Models {
    public class Almoxarifado {
        public ulong Id { get; set; }
        public string Nome { get; set; }
        public ulong? IdProj { get; set; }
        public IEnumerable<Material> MateriaisAssociados { get; set; }
        public Dictionary<ulong, decimal> RelacaoMaterialQuantidade;
    }
}
