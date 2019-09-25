using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP.Models.Validacao
{
    /// <summary>
    /// Interface para validação de modelo
    /// </summary>
    public interface IAutoValida
    {
        /// <summary>
        /// Confere se os dados do modelo estão válidos
        /// </summary>
        /// <returns></returns>
        bool Validar();
    }
}
