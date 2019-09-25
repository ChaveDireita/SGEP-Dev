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
        public Funcionario Solicitante { get; set; }
        [Display(Name = "Projeto associado")]
        public Projeto ProjSolicitante { get; set; }
        [Display(Name = "Material")]
        public Material MaterialMovimentado { get; set; }
        [Display(Name = "Data da movimentação")]
        public DateTime DataDeSolicitacao { get; set; }
        [Display(Name = "Quantidade movimentada")]
        //é bom printar isso ai acompanhado do tipo de unidade do material solicitado
        public decimal QuantidadeSolicitada { get; set; }
        //Vai ser limitada a 'retirada' ou 'inserção'(n sei o mlh nome pra isso ainda) de acordo com o valor do booleano
        [Display(Name = "Tipo de movimentação")]
        public string TipoMovimentacao { get; set; }

        public bool Validar()
        {
            return !(Solicitante == null || ProjSolicitante == null || MaterialMovimentado == null);
        }
    }
}
