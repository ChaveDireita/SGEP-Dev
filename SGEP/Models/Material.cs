using System.ComponentModel.DataAnnotations;

namespace SGEP.Models
{
    public class Material
    {
        [Key]
        public ulong Id { get; set; }
        public double Quantidade { get; set; }
        public string Nome { get; set; }
        public string Unidade { get; set; }

        private double _preco;
        [Display(Name = "Preço")]
        public double Preco
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

        public Material(ulong id, double quantidade, string nome, string unidade, double preco){
            Id = id;
            Quantidade = quantidade;
            Nome = nome;
            Unidade = unidade;
            Preco = preco;
        }
        public Material(double quantidade, string nome, string unidade, double preco){
            Id = 0;
            Quantidade = quantidade;
            Nome = nome;
            Unidade = unidade;
            Preco = preco;
        }

        public void RemoverMaterial(double quantidade)
        {
          if (quantidade > 0 && Quantidade - quantidade > 0)
            Quantidade -= quantidade;
        }

        public void AdicionarMaterial(double quantidade)
        {
          if (quantidade > 0)
            Quantidade += quantidade;
        }

    }
}
