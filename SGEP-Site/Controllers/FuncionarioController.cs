using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> Index() => View(((List<Funcionario>)await _repo.GetAllAsync()).ConvertAll(f => ModelConverter.DomainToView(f)));

        // GET: Funcionarios/Details/{id}
        public async Task<IActionResult> Details(ulong? id)//Tô usando var abaixo por preguiça de escrever o tipo completo. Mas o compilador consegue inferir sozinho
        {
            //Removido temporariamente
            /*var projetos = await _repo.Projeto.ToListAsync();//Converte o DbSet Projeto do ContextoBD numa lista.
            var participas = await _repo.ParticipaProjeto.ToListAsync();//^^^^

            var idProjetosDentro = from pp in participas
                                   from p in projetos
                                   where p.Id == pp.CodProjeto && pp.CodFuncionario == id
                                   select pp.CodProjeto;//Equivale a SELECT pp.CodProjeto FROM participas AS pp, projetos AS p WHERE p.Id=pp.CodProjeto && pp.CodFuncionario=id;(este último id é o parâmetro passado na função)

            var idProjetosFora = from p in projetos
                                 where !idProjetosDentro.Contains(p.Id)
                                 select p.Id;//Equivale a SELECT DISTINCT p.Id FROM idProjetosDentro AS pp, projetos AS p WHERE p.Id!=pp.CodProjeto;

            ViewData["projetos"] = projetos;
            ViewData["projetosDentro"] = from p in projetos
                                         from pid in idProjetosDentro
                                         where p.Id == pid
                                         select p;//Equivale a SELECT p FROM projetos AS p, idProjetosDentro as pid WHERE p.Id=pid;
            ViewData["projetosFora"] = (from p in projetos
                                        from pid in idProjetosFora
                                        where p.Id == pid
                                        select p).Distinct();//Equivale a SELECT DISTINCT p FROM projetos AS p, idProjetosFora as pid WHERE p.Id=pid;*/

            if (id == null)
                return BadRequest();
            Funcionario funcionario = _repo.Get(id.GetValueOrDefault());//Esse método é do AcoesComunsDosControllers.
            return (funcionario == null) ? (IActionResult) NotFound() : View(ModelConverter.DomainToView(funcionario));//O NotFound é aquele erro 404.
        }

        // GET: Funcionarios/Create
        public IActionResult Create() => View();

        // POST: Funcionarios/Create
        [HttpPost]//É pra dizer que é um método post (Coisa do protocolo HTTP. É um verbo que permite alterar os dados do servidor).
        [ValidateAntiForgeryToken]//Isso é pra impedir que indivíduos mal intencionados ataquem o servidor fazendo cadastros em excesso.
        public async Task<IActionResult> Create([Bind("Id,Nome,Cargo")] Funcionario funcionario)
        {
            if (funcionario.Validar())
            {
                await _repo.AddAsync(funcionario);//Esse método é do AcoesComunsDosControllers.
                return RedirectToAction(nameof(Index));
            }
            return View(ModelConverter.DomainToView(funcionario));
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {

            Funcionario funcionario = _repo.Get(id.Value);//Esse método é do AcoesComunsDosControllers.

            return (funcionario == null || id == null) ? (IActionResult)NotFound() : View(ModelConverter.DomainToView(funcionario));
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
            return View(ModelConverter.DomainToView(funcionario));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Demitir([Bind(nameof(Funcionario.Id) + "," + 
                                                       nameof(Funcionario.Nome) + "," + 
                                                       nameof(Funcionario.Cargo) + "," + 
                                                       nameof (Funcionario.Demitido))] Funcionario funcionario)
        {
            funcionario.Demitido = true;
            await _repo.UpdateAsync(funcionario);
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(ulong id) => _repo.Get(id) != null;//Gerado pelo scaffolding. Checar se o funcionário existe no banco.
    }
}
