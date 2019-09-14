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
        private readonly ContextoBD _context;

        public ProjetosController(ContextoBD context) => _context = context;

        // GET: Projetos
        public async Task<IActionResult> Index() => View(await _context.Projeto.ToListAsync());

        // GET: Projetos/Details/5
        public async Task<IActionResult> Details(ulong? id)
        {
            Projeto projeto = await _a.ChecarPeloId(id, _context.Projeto);
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
