using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGEP.Banco;
using SGEP.Models;

using _a = SGEP.Controllers.AcoesComunsDosControllers;//Dei um alias (apelido) pra classe AcoesComunsDosControllers pra não ficar um nome gigante só pra chamar um método bobo.

namespace SGEP.Controllers
{
    public class FuncionariosController : Controller
    {
        /// <summary>
        /// É uma referência ao contexto do banco de dados. É obtido através de injeção de dependência no construtor.
        /// </summary>
        private readonly ContextoBD _contexto;
        public FuncionariosController(ContextoBD context) => _contexto = context;

        // GET: Funcionarios
        public async Task<IActionResult> Index() => View(await _contexto.Funcionario.ToListAsync());

        // GET: Funcionarios/Details/{id}
        public async Task<IActionResult> Details(ulong? id)//Tô usando var abaixo por preguiça de escrever o tipo completo. Mas o compilador consegue inferir sozinho
        {
            var projetos = await _contexto.Projeto.ToListAsync();//Converte o DbSet Projeto do ContextoBD numa lista.
            var participas = await _contexto.ParticipaProjeto.ToListAsync();//^^^^

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
                                        select p).Distinct();//Equivale a SELECT DISTINCT p FROM projetos AS p, idProjetosFora as pid WHERE p.Id=pid;


            Funcionario funcionario = await _a.ChecarPeloId(id, _contexto.Funcionario);//Esse método é do AcoesComunsDosControllers.
            return (funcionario == null) ? (IActionResult) NotFound() : View(funcionario);//O NotFound é aquele erro 404.
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
                await _a.SalvarModelo(funcionario, _contexto);//Esse método é do AcoesComunsDosControllers.
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            Funcionario funcionario = await _a.ChecarPeloId(id, _contexto.Funcionario);//Esse método é do AcoesComunsDosControllers.

            return (funcionario == null) ? (IActionResult)NotFound() : View(funcionario);
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
                    await _a.AtualizarModelo(funcionario, _contexto);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Demitir([Bind(nameof(Funcionario.Id) + "," + 
                                                       nameof(Funcionario.Nome) + "," + 
                                                       nameof(Funcionario.Cargo) + "," + 
                                                       nameof (Funcionario.Demitido))] Funcionario funcionario)
        {
            funcionario.Demitido = true;
            await _a.AtualizarModelo(funcionario, _contexto);
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(ulong id) => _contexto.Funcionario.Any(e => e.Id == id);//Gerado pelo scaffolding. Checar se o funcionário existe no banco.
    }
}
