using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SGEP.Controllers
{
    public class MovimentacaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}