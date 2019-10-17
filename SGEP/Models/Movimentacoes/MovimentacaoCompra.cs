using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using SGEP.Models.Movimentacoes;
using SGEP.Models.Validacao;

namespace SGEP.Models
{
    public class MovimentacaoCompra : IMovimentacao, IAutoValida
    {
        [Key]
        [Display(Name = "Código da movimentação")]
        public ulong Id { get; set; }



        [DataType(DataType.Date)]
        [Display(Name = "Data de realização")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime Data { get; set; }


        private decimal _preco;
        [Range(0, double.PositiveInfinity, ErrorMessage = "A quantidade não pode ser menor que 0.")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Preço")]
        public decimal Preco
        {
            get => _preco;
            set
            {
                if (value > 0)
                    _preco = value;
            }
        }

        private decimal _quantidade;
        [Range(0, double.PositiveInfinity, ErrorMessage = "A quantidade não pode ser menor que 0.")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public decimal Quantidade
        {
            get => _quantidade;
            set
            {
                if (value > 0)
                    _quantidade = value;
            }
        }



        [Display(Name ="Material")]
        [ForeignKey(nameof(Material))]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public ulong MaterialMovimentado { get; set; }




        [Display(Name = "Tipo")]
        public string TipoMovimentacao { get => "Entrada"; }


        
        public bool Validar() => Quantidade > 0;
    }
}
