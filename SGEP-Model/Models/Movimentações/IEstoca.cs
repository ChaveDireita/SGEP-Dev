using System;
using System.Collections.Generic;
using System.Text;

namespace SGEP_Model.Models
{
    public interface IEstoca
    {
        void Add (ulong material, decimal quantidade);
        void Remove (ulong material, decimal quantidade);
    }
}
