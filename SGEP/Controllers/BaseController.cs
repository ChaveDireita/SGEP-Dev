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

        protected async Task<IActionResult> AcaoCriarPost<T>(bool valido, T model)
        {
            if (valido)
            {
                _contexto.Add(model);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(model));
            }
            return View();
        }

        protected async Task<IActionResult> InfoModel<T>(ulong? id, DbSet<T> tabela) where T : class
        {
            if (id == null)
                return NotFound();
            T model = await tabela.FindAsync(id);
            if (model == null)
                return NotFound();
            return View(model);
        }

        protected async Task<IActionResult> DeletarModel<T>(ulong id, DbSet<T> tabela, String redirecionamento) where T : class
        {
            T model = await tabela.FindAsync(id);
            tabela.Remove(model);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(redirecionamento);
        }
    }
}