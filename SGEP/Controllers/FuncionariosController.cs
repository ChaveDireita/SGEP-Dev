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
    public class FuncionariosController : Controller
    {
        private readonly ContextoBD _context;
        public FuncionariosController(ContextoBD context) => _context = context;

        // GET: Funcionarios
        public async Task<IActionResult> Index() => View(await _context.Funcionario.ToListAsync());

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(ulong? id)
        {
            var projetos = from f in await _context.Funcionario.ToListAsync() select f;
            var participas = from pp in await _context.ParticipaProjeto.ToListAsync() select pp;

            var idProjetosDentro = from pp in participas
                                   from p in projetos
                                   where p.Id == pp.CodProjeto && pp.CodFuncionario == id
                                   select pp.CodProjeto;

            var idProjetosFora = from p in projetos
                                 where !idProjetosDentro.Contains(p.Id)
                                 select p.Id;

            ViewData["projetos"] = projetos;
            ViewData["projetosDentro"] = from p in projetos
                                         from fid in idProjetosDentro
                                         where p.Id == fid
                                         select p;
            ViewData["projetosFora"] = (from p in projetos
                                        from fid in idProjetosFora
                                        where p.Id == fid
                                        select p).Distinct();


            Funcionario funcionario = await _a.ChecarPeloId(id, _context.Funcionario);
            return (funcionario == null) ? (IActionResult) NotFound() : View(funcionario);
        }

        // GET: Funcionarios/Create
        public IActionResult Create() => View();

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cargo")] Funcionario funcionario)
        {
            if (funcionario.Validar())
            {
                await _a.SalvarModelo(funcionario, _context);
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            Funcionario funcionario = await _a.ChecarPeloId(id, _context.Funcionario);

            return (funcionario == null) ? (IActionResult)NotFound() : View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, [Bind("Id,Nome,Cargo")] Funcionario funcionario)
        {
            if (id != funcionario.Id)
                return NotFound();

            if (funcionario.Validar())
            {
                try
                {
                    await _a.AtualizarModelo(funcionario, _context);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5

        private bool FuncionarioExists(ulong id) => _context.Funcionario.Any(e => e.Id == id);
    }
}
