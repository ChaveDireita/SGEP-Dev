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
        public string Nome {get; set;}
        [DataType(DataType.Date)]
        [Display(Name = "Data de início")]
        [Remote(action: "VerificarData", controller: "Projetos", AdditionalFields = nameof(DataInicio) + ", " + nameof(PrazoEstimado) + ", " + nameof(DataFim))]
        public DateTime DataInicio {get; set;}

        [DataType(DataType.Date)]
        [Display(Name = "Data final estimada")]
        [Remote(action: "VerificarData", controller: "Projetos", AdditionalFields = nameof(DataInicio) + ", " + nameof(PrazoEstimado))]
        public DateTime PrazoEstimado {get; set;}
        [DataType(DataType.Date)]

        [Display(Name = "Data de Término")]
        [Remote(action: "VerificarData", controller: "Projetos", AdditionalFields = nameof(DataInicio) + ", " + nameof(PrazoEstimado) + ", " + nameof(DataFim))]
        public DateTime? DataFim { get; set; } 
        public EstadoProjeto Estado { get; set; } = EstadoProjeto.Andamento;

        public bool Validar() => !string.IsNullOrEmpty(Nome) && PrazoEstimado >= DataInicio && 
                                 (DataFim == null       && Estado == EstadoProjeto.Andamento || 
                                  DataFim >= DataInicio && Estado == EstadoProjeto.Finalizado);

        public virtual ICollection<ParticipaProjeto> Participacoes { get; set; }
        public virtual ICollection<AlocacaoPossui> Alocacoes {get; set; }

        //public Dictionary <Material,double> Materiais {get; set;}

        //public void AlocarMaterial(Material m, double quantidade)
        //{
        //  if(quantidade > 0)
        //    Materiais.Add(m, quantidade);
        //}
        //public void Finalizar(DateTime dataFim)
        //{
        //    DataFim = dataFim;
        //    Estado = EstadoProjeto.Finalizado;
        //}
    }
}
