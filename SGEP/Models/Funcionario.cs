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
    public string Nome { get; set; }
    public string Cargo { get; set; }

    public bool Validar() => !string.IsNullOrEmpty(Nome) && !string.IsNullOrEmpty(Cargo);

    public virtual ICollection<ParticipaProjeto> Participacoes { get; set; }
  }
}
