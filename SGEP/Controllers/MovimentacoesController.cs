using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGEP.Models;

using SGEP.Banco;

namespace SGEP.Controllers
{
    public class MovimentacoesController : Controller
    {
        private readonly ContextoBD _contexto;
        public MovimentacoesController(ContextoBD contexto) => _contexto = contexto;
        public IActionResult Index() => View(_contexto.Movimentacoes.ToList());
        public IActionResult MoverMaterial()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MoverMaterial(Movimentacao movimentacao)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}