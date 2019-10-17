using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using SGEP.Models;
using SGEP.Models.Movimentacoes;
using SGEP.Banco;

using _a = SGEP.Controllers.AcoesComunsDosControllers;

namespace SGEP.Controllers
{
    public class MovimentacoesController : Controller
    {
        private readonly ContextoBD _contexto;
        public MovimentacoesController(ContextoBD contexto) => _contexto = contexto;
        public async Task<IActionResult> Index()
        {
            List<IMovimentacao> movimentacoes = new List<IMovimentacao>();
            (await _contexto.MovimentacaoAlocacoes.ToListAsync()).ForEach(a => movimentacoes.Add(a));
            (await _contexto.MovimentacaoCompras.ToListAsync()).ForEach(c => movimentacoes.Add(c));

            return View(movimentacoes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MoverMaterial(MovimentacaoSaida movimentacao) => await CadastrarIMovimentacao(movimentacao, movimentacao.Validar());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ComprarMaterial(MovimentacaoCompra movimentacao) => await CadastrarIMovimentacao(movimentacao, movimentacao.Validar());

        public async Task<IActionResult> DetalhesAlocacao(ulong id) => await RetorneAViewParaAMovimentacao(id, _contexto.MovimentacaoAlocacoes);

        public async Task<IActionResult> DetailsCompra(ulong id) => await RetorneAViewParaAMovimentacao(id, _contexto.MovimentacaoCompras);
        public IActionResult Create() => View();
        public async Task<IActionResult> EditAlocacao(ulong id)
        {
            //Coloquei esses ViewDatas aqui pra caso você precise
            ViewData[Chaves.MATERIAIS] = await _contexto.Material.ToListAsync();
            ViewData[Chaves.PROJETOS] = await _contexto.Projeto.ToListAsync();
            ViewData[Chaves.FUNCIONARIOS] = await _contexto.Funcionario.ToListAsync();

            return await RetorneAViewParaAMovimentacao(id, _contexto.MovimentacaoAlocacoes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAlocacao(MovimentacaoSaida movimentacao) => await EditarIMovimentacao(movimentacao, movimentacao.Validar());

        public async Task<IActionResult> EditCompra(ulong id)
        {
            //Coloquei esses ViewDatas aqui pra caso você precise
            ViewData[Chaves.MATERIAIS] = await _contexto.Material.ToListAsync();
            ViewData[Chaves.PROJETOS] = await _contexto.Projeto.ToListAsync();
            ViewData[Chaves.FUNCIONARIOS] = await _contexto.Funcionario.ToListAsync();

            return await RetorneAViewParaAMovimentacao(id, _contexto.MovimentacaoCompras);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCompra(MovimentacaoCompra movimentacao) => await EditarIMovimentacao(movimentacao, movimentacao.Validar());


        private async Task<IActionResult> RetorneAViewParaAMovimentacao<T>(ulong id, DbSet<T> tabela) where T : class, IMovimentacao
        {
            Task<T> movimentacao = _a.ChecarPeloId(id, tabela);
            if (await movimentacao == null)
                return BadRequest();
            return View(movimentacao);
        }

        private async Task<IActionResult> CadastrarIMovimentacao<T>(T movimentacao, bool validacao) where T : class, IMovimentacao
        {
            if (validacao)
            {
                await _a.SalvarModelo<T>(movimentacao as T, _contexto);
                return RedirectToAction(nameof(Index));
            }
            return View(movimentacao);
        }

        private async Task<IActionResult> EditarIMovimentacao<T>(T movimentacao, bool validacao) where T : class, IMovimentacao
        {
            if (validacao)
            {
                await _a.AtualizarModelo<T>(movimentacao as T, _contexto);
                return RedirectToAction(nameof(Index));
            }
            return View(movimentacao);
        }

        public async Task<JsonResult> VerificarQuantidade(Material material, decimal quantidade) 
        {
            ulong materialId = material.Id;
            decimal quantidadeEstoque = (await _contexto.Material.FirstOrDefaultAsync(m => m.Id == materialId)).Quantidade;
            if (quantidade > quantidadeEstoque)
                return Json("A quantidade a ser alocada é maior que a quantidade do material no estoque");
            return Json(true);
        }

    }
}