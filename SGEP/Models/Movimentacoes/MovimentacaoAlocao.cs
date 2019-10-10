using SGEP.Models.Validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using SGEP.Models.Movimentacoes;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGEP.Models
{
    public class MovimentacaoAlocacao : IAutoValida, IMovimentacao
    {
        [Key]
        [Display(Name = "Código da movimentação")]
        public ulong Id { get; set; }
        [Display(Name = "Funcionário solicitante")]
        [ForeignKey(nameof(Funcionario))]
        public ulong Solicitante { get; set; }//id do funcionário
        [Display(Name = "Projeto associado")]
        [ForeignKey(nameof(Projeto))]
        public ulong ProjSolicitante { get; set; }//id do projeto
        [Display(Name = "Material")]
        [ForeignKey(nameof(Material))]
        public ulong MaterialMovimentado { get; set; }//id do Material
        [Display(Name = "Data de realização")]
        public DateTime Data { get; set; }
        [Display(Name = "Quantidade")]
        //é bom printar isso ai acompanhado do tipo de unidade do material solicitado
        public decimal Quantidade { get; set; }
        //Vai ser limitada a 'retirada' ou 'inserção'(n sei o mlh nome pra isso ainda) de acordo com o valor do booleano
        [Display(Name = "Tipo")]
        public string TipoMovimentacao { get => "Alocação"; }

        public bool Validar()
        {
            return true;// !(Solicitante == null || ProjSolicitante == null || MaterialMovimentado == null);
        }
    }
}
