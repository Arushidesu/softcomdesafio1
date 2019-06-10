using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JsonParse.Data;
using JsonParse.Models;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Routing;
using System.Net;
using Newtonsoft.Json;
using System.Diagnostics;

namespace JsonParse.Controllers
{
    public class ContasController : Controller
    {
        private readonly ContasDbContext _context;

        public ContasController(ContasDbContext context)
        {
            _context = context;
        }

        // GET: Contas
        public async Task<IActionResult> Index()
        {
            var contasDbContext = _context.Conta.Include(c => c.Usuario);
            return View(await contasDbContext.ToListAsync());
        }

        // GET: Contas/Create
        public IActionResult Create(int id)
        {
            var wc = new WebClient();
            var json = wc.DownloadString(@"http://worldclockapi.com/api/json/est/now");
            Dictionary<string, string> jsonDes = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            //Debug.WriteLine(jsonDes["currentDateTime"]);
            ViewData["Time"] = jsonDes["currentDateTime"];
            ViewData["UsuarioId"] = id;
            return View();
        }

        // POST: Contas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContaId,Titulo,Resumo,Valor,Vencimento,UsuarioId")] Conta conta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conta);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Usuarios", new { id = conta.UsuarioId });
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", conta.UsuarioId);
            return View(conta);
        }

        // GET: Contas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conta = await _context.Conta.FindAsync(id);
            if (conta == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", conta.UsuarioId);
            return View(conta);
        }

        // POST: Contas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContaId,Titulo,Resumo,Valor,Vencimento,UsuarioId")] Conta conta)
        {
            if (id != conta.ContaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContaExists(conta.ContaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details","Usuarios", new { id = conta.UsuarioId });
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", conta.UsuarioId);
            return View(conta);
        }

        // GET: Contas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var conta = await _context.Conta.FindAsync(id);
            _context.Conta.Remove(conta);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Usuarios", new { id = conta.UsuarioId });
        }

        private bool ContaExists(int id)
        {
            return _context.Conta.Any(e => e.ContaId == id);
        }
    }
}
