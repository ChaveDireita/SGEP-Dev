using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SGEP.Models.Validacao;

namespace SGEP.Models
{
  public class Funcionario: IAutoValida
  {
    [Key]
    [Display(Name = "Código do funcionário")]
    public ulong Id { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string Cargo { get; set; }
    public bool Demitido { get; set; } = false;
    public bool Validar() => !string.IsNullOrEmpty(Nome) && !string.IsNullOrEmpty(Cargo);

    public virtual ICollection<ParticipaProjeto> Participacoes { get; set; }
  }
}
