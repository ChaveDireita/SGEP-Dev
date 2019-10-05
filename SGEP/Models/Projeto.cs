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
	    [Display(Name ="C�digo do projeto")]
        public ulong Id { get; set; }
        [Required(ErrorMessage = "Este campo � obrigat�rio")]
        public string Nome {get; set;}
        [DataType(DataType.Date)]
        [Display(Name = "Data de in�cio")]
        [Required(ErrorMessage = "Este campo � obrigat�rio")]
        //Remote serve pra direcionar a valida��o do campo de entrada para um m�todo no servidor. No caso, ele valida as entradas com o m�todo VerficarData no controller Projetos, passando por par�metro a data inicial, o prazo estimado e a data final
        [Remote(action: "VerificarData", controller: "Projetos", AdditionalFields = nameof(DataInicio) + ", " + nameof(PrazoEstimado) + ", " + nameof(DataFim))]
        public DateTime DataInicio {get; set;}

        [DataType(DataType.Date)]
        [Display(Name = "Data final estimada")]
        [Required(ErrorMessage = "Este campo � obrigat�rio")]
        [Remote(action: "VerificarData", controller: "Projetos", AdditionalFields = nameof(DataInicio) + ", " + nameof(PrazoEstimado))]
        public DateTime PrazoEstimado {get; set;}
        [DataType(DataType.Date)]
        [Display(Name = "Data de T�rmino")]
        [Required(ErrorMessage = "Este campo � obrigat�rio")]
        [Remote(action: "VerificarData", controller: "Projetos", AdditionalFields = nameof(DataInicio) + ", " + nameof(PrazoEstimado) + ", " + nameof(DataFim))]
        public DateTime? DataFim { get; set; } 
        public EstadoProjeto Estado { get; set; } = EstadoProjeto.Andamento;
        /// <summary>
        /// <seealso cref="IAutoValida"/>
        /// </summary>
        /// <returns>true se o modelo for v�lido sen�o false</returns>
        public bool Validar() => !string.IsNullOrEmpty(Nome) && PrazoEstimado >= DataInicio && 
                                 (DataFim == null       && Estado == EstadoProjeto.Andamento || 
                                  DataFim >= DataInicio && Estado == EstadoProjeto.Finalizado);
        public virtual ICollection<ParticipaProjeto> Participacoes { get; set; }
        public virtual ICollection<Transacao> Alocacoes {get; set; }
    }
}
