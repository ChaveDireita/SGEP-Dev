using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SGEP.Banco;
using SGEP.Models;

namespace SGEP.Controllers
{
    public class ProjetoController : BaseController
    {
        public ProjetoController(ContextoBD contexto) : base(contexto) { }
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Projetos.ToListAsync());
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("Id", "Nome", "PrazoEstimado", "DataInicio", "DataFim", "Estado")] Projeto projeto, bool inutil)
        {
            return await AcaoCriarPost(ModelState.IsValid, projeto);
        }

        public async Task<IActionResult> Editar(ulong id)
        {
            return await InfoModel(id, _contexto.Projetos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(ulong id, [Bind("Id", "Nome", "PrazoEstimado", "DataInicio", "DataFim", "Estado")] Projeto projeto)
        {
            if (id != projeto.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(projeto);
                    await _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_contexto.Projetos.Any(f => f.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(projeto);
        }

        public async Task<IActionResult> Detalhes(ulong? id)
        {
            return await InfoModel(id, _contexto.Projetos);
        }

        public async Task<IActionResult> Deletar(ulong? id)
        {
            return await InfoModel(id, _contexto.Projetos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletar(ulong id, bool inutil)
        {
            return await DeletarModel(id, _contexto.Projetos, nameof(Index));
        }
    }
}