﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using SGEP.Models.Movimentacoes;
using SGEP.Models.Validacao;

namespace SGEP.Models
{
    public class MovimentacaoCompra : IMovimentacao, IAutoValida
    {
        [Key]
        [Display(Name ="Código da movimentação")]
        public ulong Id { get; set; }
        [Display(Name ="Data de realização")]
        public DateTime Data { get; set; }
        public decimal Quantidade { get; set; }
        [Display(Name ="Material")]
        public Material MaterialMovimentado { get; set; }
        [Display(Name = "Tipo")]
        public string TipoMovimentacao { get; set; }

        public bool Validar() => !(MaterialMovimentado == null || Quantidade < 0);
    }
}