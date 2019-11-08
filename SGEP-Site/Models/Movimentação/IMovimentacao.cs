using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models {
    interface IMovimentacao {
        ulong Id { get; set; }
        DateTime Data { get; set; }
        decimal Quantidade { get; set; }
        string MaterialMovimentado { get; set; }
        string TipoMovimentacao { get; set; }
        string Action { get; set; }
        string FuncionarioNome { get; set; }
    }
}
