using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;

using SGEP.Banco;
using SGEP.Models;

namespace SGEP.ViewComponents
{
    public class CreateAlocacaoViewComponent : ViewComponent
    {
        private readonly ContextoBD _contexto;
        public CreateAlocacaoViewComponent(ContextoBD contexto) => _contexto = contexto;
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            ViewData[Chaves.FUNCIONARIOS] = await _contexto.Funcionario.ToListAsync();
            ViewData[Chaves.PROJETOS] = from p in _contexto.Projeto
                                        where p.Estado == Models.EstadoProjeto.Andamento
                                        select p;
            ViewData[Chaves.MATERIAIS] = from m in _contexto.Material
                                         where m.Quantidade > 0
                                         select m;
            return View();
        }
    }
}
