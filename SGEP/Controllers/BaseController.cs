using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SGEP.Banco;

namespace SGEP.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ContextoBD _contexto;
        public BaseController(ContextoBD contexto)
        {
            _contexto = contexto;
        }
    }
}