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
    public class MaterialsController : Controller
    {
        /// <summary>
        /// Uma referência ao contexto do banco de dados.
        /// </summary>
        private readonly ContextoBD _context;
        public MaterialsController(ContextoBD context) => _context = context;

        // GET: Materials
        public async Task<IActionResult> Index() => View("ManagementView", await _context.Material.ToListAsync());

        // GET: Materials/Details/5
        public async Task<IActionResult> Details(ulong? id)
        {
            Material material = await _a.ChecarPeloId(id, _context.Material);
            return (material == null) ? (IActionResult)NotFound() : View(material);
        }

        // GET: Materials/Create
        public async Task<IActionResult> Create()
	    {
		    ViewData["unidades"] = await _context.Unidades.ToListAsync();
		    return View();
	    }


        // POST: Materials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(nameof(Material.Id) + "," + nameof(Material.Quantidade) + "," + nameof(Material.Descricao) + "," + nameof(Material.Unidade) + "," + nameof(Material.Preco))] Material material)
        {
            if (material.Validar())
            {
                await _a.SalvarModelo(material, _context);
                return RedirectToAction(nameof(Index));
            }
            return View(material);
        }

        // GET: Materials/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            Material material = await _a.ChecarPeloId(id, _context.Material);
            return (material == null) ? (IActionResult)NotFound() : View(material);
        }

        // POST: Materials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, [Bind(nameof(Material.Id) + "," + nameof(Material.Quantidade) + "," + nameof(Material.Descricao) + "," + nameof(Material.Unidade) + "," + nameof(Material.Preco))] Material material)
        {
            if (id != material.Id)
                return NotFound();

            if (material.Validar())
            {
                try
                {
                    await _a.AtualizarModelo(material, _context);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialExists(material.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(material);
        }

        private bool MaterialExists(ulong id) => _context.Material.Any(e => e.Id == id);
        
    }
}
