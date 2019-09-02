using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SGEP.Models
{
    public class Projeto
    {
        [Key]
        public ulong Id { get; set; }
        public string Nome {get; set;}
        [DataType(DataType.Date)]
        [Display(Name = "Data de início")]
        public DateTime DataInicio {get; set;}
        //[DataType(DataType.Date)]
        //[Display(Name = "Data final estimada")]
        //public DateTime PrazoEstimado {get; set;}
        [DataType(DataType.Date)]
        [Display(Name = "Data de Término")]
        public DateTime? DataFim { get; set; } 
        public EstadoProjeto Estado { get; set; } = EstadoProjeto.Andamento;

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
