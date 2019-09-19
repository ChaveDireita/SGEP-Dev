using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGEP.Banco;
using SGEP.Models;

using _a = SGEP.Controllers.AcoesComunsDosControllers;

namespace SGEP.Controllers
{
    public class ProjetosController : Controller
    {
        /// <summary>
        /// Uma referência ao contexto do banco de dados.
        /// </summary>
        private readonly ContextoBD _context;

        public ProjetosController(ContextoBD context) => _context = context;

        // GET: Projetos
        public async Task<IActionResult> Index() => View(await _context.Projeto.ToListAsync());

        // GET: Projetos/Details/5
        public async Task<IActionResult> Details(ulong? id)
        {
            Projeto projeto = await _a.ChecarPeloId(id, _context.Projeto);
	        var funcionarios = from f in await _context.Funcionario.ToListAsync() select f;
            var projetos = from p in await _context.Projeto.ToListAsync() select p;
            var participas = from pp in await _context.ParticipaProjeto.ToListAsync() select pp;

            var idFuncionariosDentro = from pp in participas
                                       from f in funcionarios
                                       where f.Id == pp.CodFuncionario && pp.CodProjeto == id
                                       select pp.CodFuncionario;

            var idFuncionariosFora = from f in funcionarios
                                     where !idFuncionariosDentro.Contains(f.Id)
                                     select f.Id;

            ViewData["funcionarios"] = funcionarios;
            ViewData["funcionariosDentro"] = from f in funcionarios
                                             from fid in idFuncionariosDentro
                                             where f.Id == fid
                                             select f;
            ViewData["funcionariosFora"] = (from f in funcionarios
                                           from fid in idFuncionariosFora
                                           where f.Id == fid
                                           select f).Distinct();
            return (projeto == null) ? (IActionResult)NotFound() : View(projeto);
        }

        // GET: Projetos/Create
        public IActionResult Create() => View();

        // POST: Projetos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataInicio,PrazoEstimado,DataFim,Estado")] Projeto projeto)
        {
            if (projeto.Validar())
            {
                await _a.SalvarModelo(projeto, _context);
                return RedirectToAction(nameof(Index));
            }
            return View(projeto);
        }

        // GET: Projetos/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            Projeto projeto = await _a.ChecarPeloId(id, _context.Projeto);
            return (projeto == null) ? (IActionResult)NotFound() : View(projeto);
        }

        // POST: Projetos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, [Bind("Id,Nome,DataInicio,PrazoEstimado,DataFim,Estado")] Projeto projeto)
        {
            if (id != projeto.Id)
                return NotFound();
            

            if (projeto.Validar())
            {
                try
                {
                    await _a.AtualizarModelo(projeto, _context);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetoExists(projeto.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(projeto);
        }

        // POST: Projetos/Finalizar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Finalizar(ulong id, [Bind("Id,Nome,DataInicio,PrazoEstimado,DataFim,Estado")] Projeto projeto)
        {
            projeto.Estado = EstadoProjeto.Finalizado;

            if (id != projeto.Id)
                return NotFound();

            if (projeto.Validar())
            {
                try
                {
                    await _a.AtualizarModelo(projeto, _context);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetoExists(projeto.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            projeto.Estado = EstadoProjeto.Andamento;
            //return View(projeto);
            return RedirectToAction(nameof(Edit), new { id = projeto.Id});
        }
        private bool ProjetoExists(ulong id) => _context.Projeto.Any(e => e.Id == id);


        /// <summary>
        /// Valida as datas do projeto. Obviamente, a data inicial deve ser maior que a final real ou estimada.
        /// </summary>
        /// <param name="dataInicio">A data de início do projeto</param>
        /// <param name="prazoEstimado">A data final estimada do projeto</param>
        /// <param name="dataFim">A data final do projeto</param>
        /// <returns>Json com true caso os valores sejam válidos ou uma mensagem de erro caso não.</returns>
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerificarData(DateTime dataInicio, DateTime prazoEstimado, DateTime? dataFim)
        {
            if (dataInicio > prazoEstimado && dataFim == null)
                return Json("O prazo estimado não pode ser menor que a data inicial");
            if (dataFim != null && dataInicio > dataFim)
                return Json("A data final não pode ser menor que a data inicial");
            return Json(true);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public /*Task<*/IActionResult/*>*/ AdicionarFuncionario(ulong idProjeto, ulong idFuncionario)
        {
            /*if (_contexto.ParticipaProjetos.Any(pp => new {IdFuncionario = pp.IdFuncionario, IdProjeto = pp.IdProjeto})
                return BadRequest();
              _contexto.Add(participaProjeto);
              await _contexto.SaveChangesAsync();*/
            return View();//RETIRAR
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public /*Task<*/IActionResult/*>*/ AdicionarMaterial(ulong idProjeto, ulong idMaterial)
        {
            /*if (_contexto.ParticipaProjetos.Any(pp => new {IdFuncionario = pp.IdFuncionario, IdProjeto = pp.IdProjeto})
                return BadRequest();
              _contexto.Add(participaProjeto);
              await _contexto.SaveChangesAsync();*/
            return View();//RETIRAR
        }


    }
}
