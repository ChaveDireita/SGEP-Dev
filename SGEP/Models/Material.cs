using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SGEP.Models.Validacao;

namespace SGEP.Models
{
    public class Material : IAutoValida
    {
        [Key]
        [Display(Name ="Código do material")]
        public ulong Id { get; set; }
        [Range(0, double.PositiveInfinity, ErrorMessage = "A quantidade não pode ser menor que 0.")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public decimal Quantidade { get; set; } = 0;
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Unidade { get; set; }

        public virtual ICollection<Transacao> Alocacoes { get; set; }

        private decimal _preco;
        [Range(0, double.PositiveInfinity, ErrorMessage = "O preço não pode ser menor que 0.")]
        [Column(TypeName = "decimal(27, 2)")]
        [Display(Name = "Preço unitário")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public decimal Preco
        {
            get
            {
                return _preco;
            }
            set
            {
                if (value > 0)
                    _preco = value;
            }
        }
        public bool Validar() => Preco >= 0 && Quantidade >= 0 && !string.IsNullOrEmpty(Descricao) && !string.IsNullOrEmpty(Unidade);

        /// <summary>
        /// A quantidade de materiais pode ser aumentada com o operador <c>+</c>.
        /// Por exemplo:
        /// <code>
        /// Material m = new Material ();
        /// m.Quantidade = 2;
        /// m = m + 9; //Quantidade agora é 11
        /// </code>
        /// </summary>
        /// <param name="m">material a ter a sua quantidade aumentada</param>
        /// <param name="q">quantidade positiva a ser adicionada</param>
        /// <returns>uma cópia do material com a quantidade modificada</returns>
        public static Material operator +(Material m, decimal q)
        {
            Material novo = (Material) m.MemberwiseClone();
            if (q >= 0)
                novo.Quantidade += q;
            return novo;
                
        }
    }
}
