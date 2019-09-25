using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using SGEP.Banco;

namespace SGEP.Controllers
{
    public class MovimentacoesController : Controller
    {
        private readonly ContextoBD _contexto;
        public MovimentacoesController(ContextoBD contexto) => _contexto = contexto;
        public IActionResult Index() => View(_contexto.Movimentacoes);
    }
}