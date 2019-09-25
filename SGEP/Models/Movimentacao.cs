using SGEP.Models.Validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP.Models
{
    public class Movimentacao : IAutoValida
    {
        [Key]
        [Display(Name = "Código da movimentação")]
        public ulong Id { get; set; }
        [Display(Name = "Funcionário solicitante")]
        public Funcionario solicitante { get; set; }
        [Display(Name = "Projeto associado")]
        public Projeto projSolicitante { get; set; }
        [Display(Name = "Material")]
        public Material materialMovimentado { get; set; }
        [Display(Name = "Data da movimentação")]
        public DateTime dataDeSolicitacao { get; set; }
        [Display(Name = "Quantidade movimentada")]
        //é bom printar isso ai acompanhado do tipo de unidade do material solicitado
        public double quantidadeSolicitada { get; set; }
        //Vai ser limitada a 'retirada' ou 'inserção'(n sei o mlh nome pra isso ainda) de acordo com o valor do booleano
        [Display(Name = "Tipo de movimentação")]
        public string tipoMovimentacao { get; set; }

        public bool Validar()
        {
            return !(solicitante == null || projSolicitante == null || materialMovimentado == null);
        }
    }
}
