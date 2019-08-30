using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SGEP.Banco;

namespace SGEP.Controllers
{
    /// <summary>
    /// Superclasse de todos os outros controllers do programa. Ela faz extenso uso de métodos genérico para
    /// seguir o princípio DRY em troca de um forte acoplamento com suas classes filhas.
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// <c>_contexto</c> concede às suas subclasses acesso aos DbSets da classe ContextoBD (e, consequentemente
        /// de todos os seus campos públicos).
        /// <seealso cref="ContextoBD"/>
        /// </summary>
        protected readonly ContextoBD _contexto;
        /// <summary>
        /// O construtor apenas inicializa o campo <c>_contexto</c>
        /// </summary>
        /// <param name="contexto">Uma referência ao contexto do banco de dados utilizado</param>
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