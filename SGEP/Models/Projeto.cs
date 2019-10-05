using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

using SGEP.Models.Validacao;
using Microsoft.AspNetCore.Mvc;

namespace SGEP.Models
{
    public class Projeto : IAutoValida
    {
        [Key]
	    [Display(Name ="Código do projeto")]
        public ulong Id { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Nome {get; set;}
        [DataType(DataType.Date)]
        [Display(Name = "Data de início")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        //Remote serve pra direcionar a validação do campo de entrada para um método no servidor. No caso, ele valida as entradas com o método VerficarData no controller Projetos, passando por parâmetro a data inicial, o prazo estimado e a data final
        [Remote(action: "VerificarData", controller: "Projetos", AdditionalFields = nameof(DataInicio) + ", " + nameof(PrazoEstimado) + ", " + nameof(DataFim))]
        public DateTime DataInicio {get; set;}

        [DataType(DataType.Date)]
        [Display(Name = "Data final estimada")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Remote(action: "VerificarData", controller: "Projetos", AdditionalFields = nameof(DataInicio) + ", " + nameof(PrazoEstimado))]
        public DateTime PrazoEstimado {get; set;}
        [DataType(DataType.Date)]
        [Display(Name = "Data de Término")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Remote(action: "VerificarData", controller: "Projetos", AdditionalFields = nameof(DataInicio) + ", " + nameof(PrazoEstimado) + ", " + nameof(DataFim))]
        public DateTime? DataFim { get; set; } 
        public EstadoProjeto Estado { get; set; } = EstadoProjeto.Andamento;
        /// <summary>
        /// <seealso cref="IAutoValida"/>
        /// </summary>
        /// <returns>true se o modelo for válido senão false</returns>
        public bool Validar() => !string.IsNullOrEmpty(Nome) && PrazoEstimado >= DataInicio && 
                                 (DataFim == null       && Estado == EstadoProjeto.Andamento || 
                                  DataFim >= DataInicio && Estado == EstadoProjeto.Finalizado);
        public virtual ICollection<ParticipaProjeto> Participacoes { get; set; }
        public virtual ICollection<Transacao> Alocacoes {get; set; }
    }
}
