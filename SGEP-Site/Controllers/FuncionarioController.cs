using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using SGEP_Model.Models;
using SGEP_Services.Repository;
using SGEP_Site.Models;

namespace SGEP.Controllers
{
    public class FuncionarioController : Controller
    {
        /// <summary>
        /// É uma referência ao contexto do banco de dados. É obtido através de injeção de dependência no construtor.
        /// </summary>
        private readonly IFuncionarioRepository _repo;
        public FuncionarioController(IFuncionarioRepository repo) => _repo = repo;

        // GET: Funcionarios
        public async Task<IActionResult> Index() => View(((List<Funcionario>)await _repo.GetAllAsync()).ConvertAll(f => ModelConverterFuncionario.DomainToIndexView(f)));

        // GET: Funcionarios/Details/{id}
        public async Task<IActionResult> Details(ulong? id)
        {
            if (id == null)
                return BadRequest();

            IEnumerable<ProjetoIndexViewModel> projetos = ((List<Projeto>) await _repo.GetProjetosAsync (id.GetValueOrDefault()))
                                                                                      .ConvertAll(p => ModelConverterProjeto.DomainToIndexView(p));

            FuncionarioDetailsViewModel funcionario = ModelConverterFuncionario.DomainToDetailsView (_repo.Get(id.GetValueOrDefault()), projetos);
            return (funcionario == null) ? (IActionResult) NotFound() : View(funcionario);
        }

        // GET: Funcionarios/Create
        public IActionResult Create() => View();

        // POST: Funcionarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Cargo")] FuncionarioCreateViewModel funcionarioView)
        {
            Funcionario funcionario = ModelConverterFuncionario.ViewToDomain (funcionarioView);
            if (funcionario.Validar())
            {
                await _repo.AddAsync(funcionario);//Esse método é do AcoesComunsDosControllers.
                return RedirectToAction(nameof(Index));
            }
            return View(ModelConverterFuncionario.DomainToIndexView(funcionario));
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            if (id == null)
                return NotFound ();

            Funcionario funcionario = _repo.Get(id.GetValueOrDefault());

            return View(ModelConverterFuncionario.DomainToEditView(funcionario));
        }

        // POST: Funcionarios/Edit/{id}
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
                    await _repo.UpdateAsync(funcionario);
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
            return View(ModelConverterFuncionario.DomainToIndexView(funcionario));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Demitir (ulong? Id)
        {
            if (null == Id)
                return BadRequest ();
            _repo.Deletar (Id.GetValueOrDefault ());

            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(ulong id) => _repo.Get(id) != null;//Gerado pelo scaffolding. Checar se o funcionário existe no banco.
    }
}
