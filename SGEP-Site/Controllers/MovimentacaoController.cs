using Microsoft.AspNetCore.Mvc;
using SGEP_Services.Repository;
using SGEP_Site.Models;
using System.Collections;
using System.Collections.Generic;

namespace SGEP_Site.Controllers
{
    public class MovimentacaoController : Controller
    {
        private readonly IEntradaRepository _repoIn;
        private readonly ISaidaRepository _repoOut;

        public MovimentacaoController (IEntradaRepository repoIn, ISaidaRepository repoOut)
        {
            _repoIn = repoIn;
            _repoOut = repoOut;
        }

        // GET: Movimentacao
        public IActionResult Index()
        {
            List<MovimentacaoIndexViewModel> movimentacoes = new List<MovimentacaoIndexViewModel> ();

            foreach (var m in _repoIn.GetAll ())
                movimentacoes.Add (ModelConverterMovimentacao.DomainToIndex(m));

            foreach (var m in _repoOut.GetAll ())
                movimentacoes.Add (ModelConverterMovimentacao.DomainToIndex (m));

            movimentacoes.Sort ();

            return View(movimentacoes);
        }

        // GET: Movimentacao/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: Movimentacao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movimentacao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEntrada([Bind("PROPRIEDADES DO CREATE VIEW MODEL AQUI (Separados por vírgula)")] MovimentacaoEntradaCreateViewModel entradaView)
        {
            try
            {
                // TODO: Add insert logic here
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSaida([Bind("PROPRIEDADES DO CREATE VIEW MODEL AQUI (Separados por vírgula)")] MovimentacaoSaidaCreateViewModel saidaView)
        {
            try
            {
                // TODO: Add insert logic here
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}