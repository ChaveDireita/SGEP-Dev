using System.ComponentModel.DataAnnotations;
using SGEP.Models.Validacao;

namespace SGEP.Models
{
  public class Funcionario: IAutoValida
  {
    [Key]
    [Display(Name = "Código do funcionário")]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public string Projeto { get; set; }
    [Display(Name ="Projeto Associado")]

    public bool Validar() => !string.IsNullOrEmpty(Nome) && !string.IsNullOrEmpty(Cargo);
  }
}
