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
    public class MaterialController : BaseController
    {
        public MaterialController(ContextoBD contexto) : base(contexto) { }
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Materiais.ToListAsync());
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("Id", "Quantidade", "Nome", "Unidade", "Preco")] Material material, bool inutil)
        {
            return await AcaoCriarPost(ModelState.IsValid, material);
        }

        public async Task<IActionResult> Editar(ulong id)
        {
            return await InfoModel(id, _contexto.Materiais);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(ulong id, [Bind("Id", "Quantidade", "Nome", "Unidade", "Preco")] Material material)
        {
            if (id != material.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(material);
                    await _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_contexto.Materiais.Any(f => f.Id == id))
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
            return View(material);
        }

        public async Task<IActionResult> Detalhes(ulong? id)
        {
            return await InfoModel(id, _contexto.Materiais);
        }

        public async Task<IActionResult> Deletar(ulong? id)
        {
            return await InfoModel(id, _contexto.Materiais);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletar(ulong id, bool inutil)
        {
            return await DeletarModel(id, _contexto.Materiais, nameof(Index));
        }
    }
}