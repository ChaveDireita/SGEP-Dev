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

        // GET: Projetos/Details/{id}
        public async Task<IActionResult> Details(ulong? id)
        {
            Projeto projeto = await _a.ChecarPeloId(id, _context.Projeto);//Esse método é do AcoesComunsDosControllers.
            var funcionarios = await _context.Funcionario.ToListAsync();
            var participas = await _context.ParticipaProjeto.ToListAsync();

            var idFuncionariosDentro = from pp in participas
                                       from f in funcionarios
                                       where f.Id == pp.CodFuncionario && pp.CodProjeto == id
                                       select pp.CodFuncionario;//Equivale a SELECT pp.CodFuncionario FROM participas AS pp, funcionarios AS f WHERE f.Id=pp.CodFuncionario && pp.CodProjeto=id;(este último id é o parâmetro passado na função)

            var idFuncionariosFora = from f in funcionarios
                                     where !idFuncionariosDentro.Contains(f.Id)
                                     select f.Id;//Equivale a SELECT DISTINCT f.Id FROM idFuncionariosDentro AS ff, funcionarios AS f WHERE f.Id!=ff.CodFuncionario;

            ViewData["funcionarios"] = funcionarios;
            ViewData["funcionariosDentro"] = from f in funcionarios
                                             from fid in idFuncionariosDentro
                                             where f.Id == fid
                                             select f;//Equivale +- a SELECT f.* FROM funcionarios AS f, idFuncionariosDentro AS fid WHERE f.Id=fid;
            ViewData["funcionariosFora"] = (from f in funcionarios
                                           from fid in idFuncionariosFora
                                           where f.Id == fid
                                           select f).Distinct();//Equivale a SELECT DISTINCT f FROM funcionarios AS f, idFuncionariosFora as fid WHERE f.Id=fid;
            return (projeto == null) ? (IActionResult)NotFound() : View(projeto);
        }

        // GET: Projetos/Create
        public IActionResult Create() => View();

        // POST: Projetos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataInicio,PrazoEstimado,DataFim,Estado")] Projeto projeto)
        {
            if (projeto.Validar())
            {
                await _a.SalvarModelo(projeto, _context);//Esse método é do AcoesComunsDosControllers.
                return RedirectToAction(nameof(Index));
            }
            return View(projeto);
        }

        // GET: Projetos/Edit/{id}
        public async Task<IActionResult> Edit(ulong? id)
        {
            Projeto projeto = await _a.ChecarPeloId(id, _context.Projeto);//Esse método é do AcoesComunsDosControllers.
            return (projeto == null) ? (IActionResult)NotFound() : View(projeto);
        }

        // POST: Projetos/Edit/5
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
                    await _a.AtualizarModelo(projeto, _context);//Esse método é do AcoesComunsDosControllers.
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
                    await _a.AtualizarModelo(projeto, _context);//Esse método é do AcoesComunsDosControllers.
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
            return RedirectToAction(nameof(Edit), new { id = projeto.Id});
        }
        private bool ProjetoExists(ulong id) => _context.Projeto.Any(e => e.Id == id);
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarFuncionario(ulong? id, ulong[] fids)
        {
            var deveSerVazio = from pp in _context.ParticipaProjeto
                               from fid in fids
                               where pp.CodProjeto == id && (pp.CodFuncionario == fid)
                               select fid;

            if (deveSerVazio.Count() > 0 || id == null)
                return BadRequest();

            foreach (ulong fid in fids)
                _context.Add(new ParticipaProjeto() { CodProjeto = id.GetValueOrDefault(), CodFuncionario = fid });

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = id });
        }

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
    }
}
