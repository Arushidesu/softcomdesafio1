using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JsonParse.Models;
using System.Net;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using JsonParse.Data;

namespace JsonParse.Controllers
{
    public class HomeController : Controller
    {

        private readonly ContasDbContext _context;

        public HomeController(ContasDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["clientes"] = _context.Usuario.Count();
            ViewData["contas"] = _context.Conta.Count();
            ViewData["valores"] = _context.Conta.Sum(c => c.Valor).ToString("C");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
