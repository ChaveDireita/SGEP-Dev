using Microsoft.AspNetCore.Mvc;
using SGEP_Model.Models;
using SGEP_Services.Repository;
using SGEP_Site.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGEP_Site.Controllers
{
    public class MovimentacaoController : Controller
    {
        private readonly IEntradaRepository _repoIn;
        private readonly ISaidaRepository _repoOut;
        private readonly IMaterialRepository _repoMat;
        private readonly IAlmoxarifadoRepository _repoAlm;

        public MovimentacaoController (IEntradaRepository repoIn, ISaidaRepository repoOut, IMaterialRepository repoMat, IAlmoxarifadoRepository repoAlm)
        {
            _repoIn = repoIn;
            _repoOut = repoOut;
            _repoMat = repoMat;
            _repoAlm = repoAlm;
        }

        // GET: Movimentacao
        public IActionResult Index()
        {
            List<MovimentacaoIndexViewModel> movimentacoes = new List<MovimentacaoIndexViewModel> ();

            foreach (var m in _repoIn.GetAll ())
                movimentacoes.Add (ModelConverterMovimentacao.DomainToIndexView(m));

            foreach (var m in _repoOut.GetAll ())
                movimentacoes.Add (ModelConverterMovimentacao.DomainToIndexView (m));

            movimentacoes.Sort ();

            return View(movimentacoes);
        }

        // GET: Movimentacao/Details/Entrada/5
        [HttpGet("/Movimentacao/{tipo}/Details/{id}")]
        public IActionResult Details(string tipo, ulong id)
        {
            MovimentacaoDetailsViewModel movimentacao = null;

            switch (tipo) 
            {
                case "Entrada":
                    movimentacao = ModelConverterMovimentacao.DomainToDetailsView (_repoIn.Get (id));
                    break;
                case "Saida":
                    break;
                default:
                    return BadRequest ();
            }

            return View(movimentacao);
        }

        // GET: Movimentacao/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("/Movimentacao/Entrada/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEntrada([Bind(nameof(EntradaCreateViewModel.AlmoxarifadoId) + "," +
                                                             nameof(EntradaCreateViewModel.MaterialId)     + "," +
                                                             nameof(EntradaCreateViewModel.Quantidade))] EntradaCreateViewModel entradaView)
        {
            try
            {
                Almoxarifado almoxarifado = _repoAlm.Get (entradaView.AlmoxarifadoId);
                Material material = _repoMat.Get (entradaView.MaterialId);
                if (material == null || almoxarifado == null)
                    return NotFound ();

                if (almoxarifado.Materiais.ContainsKey (entradaView.MaterialId))
                    almoxarifado.Materiais[entradaView.MaterialId] += entradaView.Quantidade;
                else
                    almoxarifado.Materiais[entradaView.MaterialId] = entradaView.Quantidade;

                Entrada entrada = ModelConverterMovimentacao.CreateViewToDomain (entradaView, material, almoxarifado);

                await _repoAlm.UpdateAsync (almoxarifado);
                await _repoIn.AddAsync (entrada);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Create");
            }
        }

        [HttpPost("/Movimentacao/Saida/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSaida([Bind(nameof(SaidaCreateViewModel.AlmoxarifadoDestinoId) + "," +
                                               nameof(SaidaCreateViewModel.AlmoxarifadoOrigemId)  + "," +
                                               nameof(SaidaCreateViewModel.Funcionario)         + "," +
                                               nameof(SaidaCreateViewModel.MaterialId)            + "," +
                                               nameof(SaidaCreateViewModel.Quantidade))] SaidaCreateViewModel saidaView)
        {
            //try
            //{
                Almoxarifado destino = _repoAlm.Get (saidaView.AlmoxarifadoDestinoId);
                Almoxarifado origem = _repoAlm.Get (saidaView.AlmoxarifadoOrigemId);
                Material material = _repoMat.Get (saidaView.MaterialId);

                Saida saida = ModelConverterMovimentacao.CreateViewToDomain (saidaView, material, destino, origem);

                destino.Materiais[material.Id] += saidaView.Quantidade;
                origem.Materiais[material.Id] -= saidaView.Quantidade;

                await _repoAlm.UpdateAsync (destino);
                await _repoAlm.UpdateAsync (origem);
                await _repoOut.AddAsync (saida);

                return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}