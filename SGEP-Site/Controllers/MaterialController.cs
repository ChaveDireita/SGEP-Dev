using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGEP_Model.Models;
using SGEP_Services.Repository;
using SGEP_Site.Models;

namespace SGEP_Site.Controllers
{
    public class MaterialController : Controller
    {
        private IMaterialRepository _repo;

        public MaterialController (IMaterialRepository repo) =>_repo = repo;
        public async Task<IActionResult> Index () => View ((await _repo.GetAllAsync ())
                                                                       .ToList()
                                                                       .ConvertAll(m => ModelConverterMaterial.DomainToIndexView(m)));

        public IActionResult Create () => View ();
        public IActionResult Details (ulong? id) 
        {
            Material material = _repo.Get (id.GetValueOrDefault ());
            if (id == null || material == null)
                return NotFound ();
            return View (ModelConverterMaterial.DomainToDetailsView (material));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind (nameof (MaterialCreateViewModel.Quantidade) + "," + 
                                                        nameof (MaterialCreateViewModel.Descricao) + "," + 
                                                        nameof (MaterialCreateViewModel.Unidade) + "," + 
                                                        nameof (MaterialCreateViewModel.Preco))] MaterialCreateViewModel materialCreate)
        {
            Material material = ModelConverterMaterial.CreateViewToDomain (materialCreate);
            if (material.Validar ())
            {
                await _repo.AddAsync (material);
                return RedirectToAction (nameof (Index));
            }
            return View (materialCreate);
        }
        
        [HttpGet]
        public IActionResult Edit (ulong? id)
        { 
            Material material = _repo.Get (id.GetValueOrDefault());
            if (id == null || material == null)
                RedirectToAction (nameof (Index));

            return View (ModelConverterMaterial.DomainToEditView(material));
        }

        [HttpPost]//No controller dos funcionários explica isso.
        [ValidateAntiForgeryToken]//No controller dos funcionários explica isso.
        public async Task<IActionResult> Edit (ulong id, [Bind (nameof (MaterialEditViewModel.Id) + "," + 
                                                                nameof (MaterialEditViewModel.Quantidade) + "," + 
                                                                nameof (MaterialEditViewModel.Descricao) + "," + 
                                                                nameof (MaterialEditViewModel.Unidade) + "," + 
                                                                nameof (MaterialEditViewModel.Preco))] MaterialEditViewModel materialEdit)
        {
            if (id != materialEdit.Id)
                return NotFound ();

            Material material = ModelConverterMaterial.EditViewToDomain (materialEdit);

            if (material.Validar ())
            {
                try
                {
                    await _repo.UpdateAsync (material);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialExists (material.Id))
                        return NotFound ();
                    else
                        throw;
                }
                return RedirectToAction (nameof (Index));
            }
            return View (material);
        }
        private bool MaterialExists (ulong id) => _repo.Get(id) != null;
    }
}