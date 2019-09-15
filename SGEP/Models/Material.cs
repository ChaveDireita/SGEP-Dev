using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SGEP.Models.Validacao;

namespace SGEP.Models
{
    public class Material: IAutoValida
    {
        [Key]
        public ulong Id { get; set; }
        [Range(0, double.PositiveInfinity, ErrorMessage = "A quantidade não pode ser menor que 0.")]
        public decimal Quantidade { get; set; } = 0;
        public string Descricao { get; set; }
        public string Unidade { get; set; }

        public virtual ICollection<AlocacaoPossui> Alocacoes {get; set; }

        private decimal _preco;
        [Range(0, double.PositiveInfinity, ErrorMessage = "O preço não pode ser menor que 0.")]
        [Column(TypeName = "decimal(27, 2)")]
        public decimal PrecoUnitario
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

        public bool Validar() => PrecoUnitario >= 0 && Quantidade >= 0 && !string.IsNullOrEmpty(Descricao) && !string.IsNullOrEmpty(Unidade);

        //public void RemoverMaterial(double quantidade)
        //{
        //  if (quantidade > 0 && Quantidade - quantidade > 0)
        //    Quantidade -= quantidade;
        //}
        //
        //public void AdicionarMaterial(double quantidade)
        //{
        //  if (quantidade > 0)
        //    Quantidade += quantidade;
        //}

    }
}
