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

namespace JsonParse.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ContasDbContext _context;

        public UsuariosController(ContasDbContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index(int? id, string SearchString, int page = 1, string sortExpression = "Nome")
        {
            if (id > 0)
            {
                ViewData["usuario"] = _context.Usuario.Where(u => u.UsuarioId == id).ToList()[0].Nome;
            }

            var qry = _context.Usuario.AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchString))
            {
                SearchString = SearchString.ToLower();
                qry = qry.Where(c => c.Nome.ToLower().Contains(SearchString) | c.Email.ToLower().Contains(SearchString) | c.Fone.ToLower().Contains(SearchString));
            }

            var model = await PagingList.CreateAsync(qry, 5, page, sortExpression, "Nome");

            model.RouteValue = new RouteValueDictionary {
                { "SearchString", SearchString}
            };

            return View(model);
        }


        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id, string SearchString, int page = 1, string sortExpression = "Vencimento")
        {
            if (id == null)
            {
                return NotFound();
            }

            var contasquery = _context.Conta.AsQueryable();

            var qry = contasquery
                .Where(c => c.UsuarioId == id);

            if (qry.ToList().Count < 1)
            {
                return RedirectToAction("Index", "Usuarios", new { id = id });
            }

            ViewData["UsuarioData"] = _context.Usuario.ToList().Find(u => u.UsuarioId == id);
            ViewData["total"] = qry.ToList().Count();
            ViewData["common"] = qry.ToList().GroupBy(c => c.Resumo).OrderByDescending(g => g.Count()).Select(g => g.Key).First();
            ViewData["max"] = qry.ToList().Max(c => c.Valor);
            ViewData["min"] = qry.ToList().Min(c => c.Valor);
            ViewData["countFuture"] = qry.ToList().Where(c => c.Vencimento >= DateTime.Now).Count();

            if (!string.IsNullOrWhiteSpace(SearchString))
            {
                SearchString = SearchString.ToLower();
                qry = qry.Where(c => c.Titulo.ToLower().Contains(SearchString) | c.Resumo.ToLower().Contains(SearchString) | c.Valor.ToString().Contains(SearchString) | c.Vencimento.ToString().Contains(SearchString));
            }

            var model = await PagingList.CreateAsync(qry, 5, page, sortExpression, "Vencimento");

            model.RouteValue = new RouteValueDictionary {
                { "SearchString",SearchString}
            };

            return View(model);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,Nome,Email,Fone")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,Nome,Email,Fone")] Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.UsuarioId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var employee = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.UsuarioId == id);
        }
    }
}
