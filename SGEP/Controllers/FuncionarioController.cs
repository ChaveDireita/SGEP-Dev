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
    public class FuncionarioController : BaseController
    {
        public FuncionarioController(ContextoBD contexto) : base(contexto) { }
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Funcionarios.ToListAsync());
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("Id", "Nome")] Funcionario funcionario, bool inutil)
        {
            return await AcaoCriarPost(ModelState.IsValid, funcionario);
        }

        public async Task<IActionResult> Editar(ulong id)
        {
            return await InfoModel(id, _contexto.Funcionarios);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(ulong id, [Bind("Id", "Nome")] Funcionario funcionario)
        {
            if (id != funcionario.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(funcionario);
                    await _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_contexto.Funcionarios.Any(f => f.Id == id))
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
            return View(funcionario);
        }

        public async Task<IActionResult> Detalhes(ulong? id)
        {
            return await InfoModel(id, _contexto.Funcionarios);
        }

        public async Task<IActionResult> Deletar(ulong? id)
        {
            return await InfoModel(id, _contexto.Funcionarios);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletar(ulong id, bool inutil)
        {
            return await DeletarModel(id, _contexto.Funcionarios, nameof(Index));
        }
    }
}