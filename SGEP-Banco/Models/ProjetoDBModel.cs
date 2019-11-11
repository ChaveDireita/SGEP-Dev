using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGEP_Banco.Models
{
    public class ProjetoDBModel
    {
        public ulong Id { get; set; }
        [ForeignKey(nameof (AlmoxarifadoDBModel))]
        public ulong AlmoxarifadoId { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime PrazoEstimado { get; set; }
    }
    public class FuncionarioProjetoDBModel
    {
        [ForeignKey (nameof (FuncionarioDBModel))]
        public ulong FuncionarioId { get; set; }
        [ForeignKey (nameof (ProjetoDBModel))]
        public ulong ProjetoId { get; set; }
    }
}
