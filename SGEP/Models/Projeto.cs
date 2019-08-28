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
        [Display(Name = "Data de início")]
        public DateTime DataInicio {get; set;}
        [Display(Name = "Data final estimada")]
        public DateTime PrazoEstimado {get; set;}
        [Display(Name = "Data final")]
        public DateTime? DataFim {get; set;}
        public EstadoProjeto Estado {get; set;}
        //public Dictionary <Material,double> Materiais {get; set;}

        public Projeto(string nome,DateTime dataInicio,DateTime prazoEstimado){
            Id = 0;
            Nome = nome;
            DataInicio = dataInicio;
            PrazoEstimado = prazoEstimado;
        }
        public Projeto(ulong id,string nome,DateTime dataInicio,DateTime prazoEstimado){
            Id = id;
            Nome = nome;
            DataInicio = dataInicio;
            PrazoEstimado = prazoEstimado;
        }
        public Projeto(ulong id,string nome,DateTime dataInicio,DateTime prazoEstimado,DateTime dataFim){
            Id = id;
            Nome = nome;
            DataInicio = dataInicio;
            PrazoEstimado = prazoEstimado;
            DataFim = dataFim;
        }

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
