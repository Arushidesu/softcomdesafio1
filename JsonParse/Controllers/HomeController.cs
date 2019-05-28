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

namespace JsonParse.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            string dir = System.IO.Directory.GetCurrentDirectory();
            var wc = new WebClient();
            var json = wc.DownloadString(dir + @"\wwwroot\lib\json\contas.json");
            wc.Encoding = Encoding.UTF8;
            Debug.WriteLine(json);
            var usuario = JsonConvert.DeserializeObject<Usuario>(json);
            List<Conta> sortedContas = usuario.contas.OrderBy(c => c.vencimento).ToList();
            usuario.contas = sortedContas;
            ViewBag.Message = usuario;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
