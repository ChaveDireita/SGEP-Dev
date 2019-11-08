using SGEP_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public class MovimentacaoEntradaCreateViewModel
    {
        public MovimentacaoEntradaViewModel Movimentacao { get; set; }
        //Precisa ID de IEstoque(Destino)
        public decimal Preco { get; set; }
        public IEnumerable<Funcionario> NomeFuncionario { get; set; }
        public IEnumerable<Material> NomeMaterial { get; set; }

    }
}
