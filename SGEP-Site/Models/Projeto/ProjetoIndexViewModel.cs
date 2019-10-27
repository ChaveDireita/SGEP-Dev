﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Models
{
    public struct ProjetoIndexViewModel
    {
        public ulong Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime PrazoEstimado { get; set; }
        public DateTime? DataFim { get; set; }
        public string Estado { get; set; }
    }
}