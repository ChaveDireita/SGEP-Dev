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
        /// <summary>
        /// O construtor apenas chama o da superclasse. Nada mais. 
        /// </summary>
        /// <param name="contexto"><see cref="BaseController"/></param>
        public FuncionarioController(ContextoBD contexto) : base(contexto) { }
        /// <summary>
        /// <c>Index</c> chama a view correspondente, passando uma <c>List</c> de <c>Funcionario</c>
        /// como parâmetro.
        /// </summary>
        /// <returns>A view <c>Funcionario.Index</c></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Funcionarios.ToListAsync());
        }
        /// <summary>
        /// Chama a tela de cadastro de Funcionário.
        /// </summary>
        /// <returns>Retorna a view de cadastro de Funcionário</returns>
        public IActionResult Criar()
        {
            return View();
        }
        /// <summary>
        /// Método post chamado quando o botão 'cadastrar' da tela de cadastro
        /// de Funcionário é clicado. Ele adiciona um novo Funcionário ao banco,
        /// caso os dados inseridos sejam válidos.
        /// </summary>
        /// <param name="funcionario">Parâmetro do tipo Funcionario com os dados inseridos</param>
        /// <returns>Uma chamada a AcaoCriarPost, com o argumento funcionario sendo passado por
        /// parâmetro.<seealso cref="BaseController.AcaoCriarPost{T}(T)"/></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("Id", "Nome")] Funcionario funcionario)
        {
            return await AcaoCriarPost(funcionario);
        }
        /// <summary>
        /// Chama a view <c>Funcionario.Editar</c>, com as informações da tupla da tabela Funcionario no banco
        /// cuja chave primária seja <c>id</c>;
        /// </summary>
        /// <param name="id">chave primária da tupla na tabela Funcionario do banco</param>
        /// <returns><seealso cref="BaseController.InfoModel{T}(ulong?, DbSet{T})"/></returns>
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