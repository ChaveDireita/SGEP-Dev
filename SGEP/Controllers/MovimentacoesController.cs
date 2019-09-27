using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using SGEP.Models;
using SGEP.Models.Movimentacoes;
using SGEP.Banco;

namespace SGEP.Controllers
{
    public class MovimentacoesController : Controller
    {
        private readonly ContextoBD _contexto;
        public MovimentacoesController(ContextoBD contexto) => _contexto = contexto;
        public async Task<IActionResult> Index()
        {
            List<IMovimentacao> movimentacoes = new List<IMovimentacao>();
            (await _contexto.MovimentacaoAlocacoes.ToListAsync()).ForEach(a => movimentacoes.Add(a));
            (await _contexto.MovimentacaoCompras.ToListAsync()).ForEach(c => movimentacoes.Add(c));

            return View(movimentacoes);
        }
        public async Task<IActionResult> MoverMaterial()
        {
            ViewData["materiais"] = await _contexto.Material.ToListAsync();
            ViewData["projetos"] = await _contexto.Projeto.ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MoverMaterial(MovimentacaoAlocacao movimentacao)
        {
            
            return RedirectToAction(nameof(Index));
        }
    }
}