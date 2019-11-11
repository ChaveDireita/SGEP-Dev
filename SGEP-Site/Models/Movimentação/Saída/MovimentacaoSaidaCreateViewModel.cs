using SGEP_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public class MovimentacaoSaidaCreateViewModel
    {
        //public MovimentacaoSaidaViewModel Movimentacao { get; set; }
        //Precisa IEstoque(Destino)
        //Precisa IEstoque(Origem)
        public IEnumerable<Funcionario> NomeFuncionario { get; set; }
    }
}
