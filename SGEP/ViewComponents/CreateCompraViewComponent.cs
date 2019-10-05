using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;

using SGEP.Banco;

namespace SGEP.ViewComponents
{
    public class CreateCompraViewComponent : ViewComponent
    {
        private readonly ContextoBD _contexto;
        public CreateCompraViewComponent(ContextoBD contexto) => _contexto = contexto;
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["materiais"] = await _contexto.Material.ToArrayAsync();
            return View();
        }
    }
}
