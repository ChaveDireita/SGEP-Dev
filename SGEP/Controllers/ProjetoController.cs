using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SGEP.Banco;

namespace SGEP.Controllers
{
    public class ProjetoController : BaseController
    {
        public ProjetoController(ContextoBD contexto) : base(contexto) { }
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Projetos.ToListAsync());
        }
    }
}