using System;
using System.Collections.Generic;
using System.Text;

namespace SGEP_Model.Models 
{
    public class AlmoxarifadoGeral : IEstoca
    {
        public IDictionary<ulong, decimal> Materiais { get; set; }
        public void Add (ulong material, decimal quantidade)
        {
            if (Materiais.ContainsKey (material))
                Materiais[material] += quantidade;
            else
                Materiais[material] = quantidade;
        }

        public void Remove (ulong material, decimal quantidade)
        {
            if (Materiais.ContainsKey (material) && Materiais[material] >= quantidade)
                Materiais[material] += quantidade;
            else
                Materiais[material] = quantidade;
        }
    }

    public class AlmoxarifadoProjeto : IEstoca
    {
        public ulong ProjetoId { get; set; }
        public IDictionary<ulong, decimal> Materiais { get; set; }
        public void Add (ulong material, decimal quantidade)
        {
            if (Materiais.ContainsKey (material))
                Materiais[material] += quantidade;
            else
                Materiais[material] = quantidade;
        }

        public void Remove (ulong material, decimal quantidade)
        {
            if (Materiais.ContainsKey (material) && Materiais[material] >= quantidade)
                Materiais[material] += quantidade;
            else
                Materiais[material] = quantidade;
        }
    }
}
