using System.ComponentModel.DataAnnotations;

namespace SGEP.Models
{
  public class Funcionario
  {
    [Key]
    public ulong Id { get; set; }
    public string Nome { get; set; }    
  }
}
