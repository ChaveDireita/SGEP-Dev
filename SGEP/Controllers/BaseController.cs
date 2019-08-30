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
        /// <summary>
        /// <c>AcaoCriarPost</c> é uma generalização da função cadastrar para qualquer classe model.
        /// Ele deve possuir um DbSet equivalente na classe ContextoBD.
        /// </summary>
        /// <typeparam name="T">Tipo de dado do modelo a ser salvo no banco. </typeparam>
        /// <seealso cref="ContextoBD"/>
        /// <param name="model"></param>
        /// <returns>Caso o cadastro seja bem sucedido, ele retornará uma chamada ao método <c>Index()</c>.
        /// Caso contrário, a view da mesma página.</returns>
        protected async Task<IActionResult> AcaoCriarPost<T>(T model)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(model);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(model));
            }
            return View();
        }
        /// <summary>
        /// <c>InfoModel</c> é uma generalização da função de exibir informações. Assim como o <c>AcaoCriarPost</c>,
        /// é necessárrio que a classe model tenha sua conrapartida na classe ContextoBD
        /// <seealso cref="AcaoCriarPost{T}(T)"/>
        /// </summary>
        /// <typeparam name="T">Tipo de dado do model</typeparam>
        /// <param name="id">Chave primária anulável da tupla</param>
        /// <param name="tabela">DbSet equivalente da classe ContextoBD. Obtido através da propriedade
        /// <c>_contexto</c></param>
        /// <seealso cref="_contexto"/>
        /// <returns>Caso a tupla cuja chave seja <c>id</c> tenha sido encontrada, devolve <c>View(model)</c>,
        /// Caso contrário, <c>NotFound()</c></returns>
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