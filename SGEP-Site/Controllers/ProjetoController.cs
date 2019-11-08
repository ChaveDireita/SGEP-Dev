using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGEP_Model.Models;
using SGEP_Services.Repository;
using SGEP_Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGEP_Site.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly IProjetoRepository _repo;

        public ProjetoController (IProjetoRepository repo) => _repo = repo;

        // GET: Projetos
        public async Task<IActionResult> Index () => View ((await _repo.GetAllAsync ())
                                                                       .ToList ()
                                                                       .ConvertAll (p => ModelConverterProjeto.DomainToIndexView (p)));
        
        // GET: Projetos/Details/{id}
        public async Task<IActionResult> Details (ulong? id)
        {
            if (id == null)
                return NotFound ();

            Projeto projeto = _repo.Get (id.GetValueOrDefault());

            if (projeto == null)
                return NotFound ();

            IEnumerable<Funcionario> funcionarios = await _repo.GetFuncionariosAsync (id.GetValueOrDefault ());
            IEnumerable<Funcionario> funcionariosFora = _repo.GetFuncionariosFora (id.GetValueOrDefault ());

            ProjetoDetailsViewModel projetoDetails = ModelConverterProjeto.DomainToDetailsView (projeto, funcionarios, funcionariosFora);
            
            return View (projetoDetails);
        }

        // GET: Projetos/Create
        public IActionResult Create () => View ();

        // POST: Projetos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind ("Nome,DataInicio,PrazoEstimado")] ProjetoCreateViewModel projetoViewModel)
        {
            Projeto projeto = ModelConverterProjeto.CreateViewToDomain (projetoViewModel);
            if (projeto.Validar ())
            {
                await _repo.AddAsync (projeto);
                return RedirectToAction (nameof (Index));
            }
            return View (projeto);
        }

        // GET: Projetos/Edit/{id}
        public async Task<IActionResult> Edit (ulong? id)
        {
            if (null == id)
                return BadRequest ();

            Projeto projeto = _repo.Get (id.GetValueOrDefault());
            
            return (projeto == null) ? (IActionResult) NotFound () : View (ModelConverterProjeto.DomainToEditView (projeto));
        }

        // POST: Projetos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (ulong id, [Bind ("Id,Nome,DataInicio,PrazoEstimado,DataFim")] ProjetoEditViewModel projetoView)
        {
            if (id != projetoView.Id)
                return NotFound ();

            Projeto projeto = ModelConverterProjeto.EditViewToDomain (projetoView);

            if (projeto.Validar ())
            {
                try
                {
                    await _repo.UpdateAsync (projeto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetoExists (projeto.Id))
                        return NotFound ();
                    else
                        throw;
                }
                return RedirectToAction (nameof (Index));
            }
            
            return View(projeto);
        }

        // POST: Projetos/Finalizar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Finalizar (ulong id, [Bind ("Id,Nome,DataInicio,PrazoEstimado,DataFim")] ProjetoEditViewModel projetoView)
        {
            Projeto projeto = ModelConverterProjeto.EditViewToDomain (projetoView);

            projeto.Estado = EstadoProjeto.Finalizado;

            if (id != projeto.Id)
                return NotFound ();

            if (projeto.Validar ())
            {
                try
                {
                    await _repo.UpdateAsync (projeto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetoExists (projeto.Id))
                        return NotFound ();
                    else
                        throw;
                }
                return RedirectToAction (nameof (Index));
            }
            projeto.Estado = EstadoProjeto.Andamento;
            return RedirectToAction (nameof (Edit), new { id = projeto.Id });
        }
        private bool ProjetoExists (ulong id) => _repo.Get (id) != null;
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarFuncionario (ulong? id, ulong[] fids, [FromServices] IFuncionarioRepository funcionarioRepo)
        {
            if (id == null)
                return BadRequest ();

            IEnumerable<Funcionario> funcionariosDentro = await _repo.GetFuncionariosAsync (id.GetValueOrDefault ());

            var deveSerVazio = funcionariosDentro.ToList ()
                                                 .ConvertAll (fd => fd.Id)
                                                 .Intersect (fids);

            if (deveSerVazio.Count () > 0)
                return BadRequest ();

            Projeto p = _repo.Get (id.GetValueOrDefault());

            foreach (ulong fid in fids)
                await _repo.AddFuncionarioAsync (p, funcionarioRepo.Get(fid));

            return RedirectToAction (nameof (Details), new { id = id });
        }

        /// <summary>
        /// Valida as datas do projeto. Obviamente, a data inicial deve ser maior que a final real ou estimada.
        /// </summary>
        /// <param name="dataInicio">A data de início do projeto</param>
        /// <param name="prazoEstimado">A data final estimada do projeto</param>
        /// <param name="dataFim">A data final do projeto</param>
        /// <returns>Json com true caso os valores sejam válidos ou uma mensagem de erro caso não.</returns>
        [AcceptVerbs ("GET", "POST")]
        public IActionResult VerificarData (DateTime dataInicio, DateTime prazoEstimado, DateTime? dataFim)
        {
            if (dataInicio > prazoEstimado && dataFim == null)
                return Json ("O prazo estimado não pode ser menor que a data inicial");
            if (dataFim != null && dataInicio > dataFim)
                return Json ("A data final não pode ser menor que a data inicial");
            return Json (true);
        }
    }
}
