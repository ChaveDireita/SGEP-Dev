using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using SGEP.Models;
using SGEP.Banco;

namespace SGEP.Controllers
{
    public class UnidadeController : Controller
    {
        private readonly ContextoBD _contexto;
        public UnidadeController(ContextoBD contexto) => _contexto = contexto;

        public IActionResult Index() => View();

        public IActionResult Unidades() => View();

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Unidade")] Unidades unidades)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(unidades);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Unidades));
        }
    }
}