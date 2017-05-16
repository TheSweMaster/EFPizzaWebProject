using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFPizza.WebApp.Models;

namespace EFPizza.WebApp.Controllers
{
    public class OrginsController : Controller
    {
        private readonly EFPizzaContext _context;

        public OrginsController(EFPizzaContext context)
        {
            _context = context;    
        }

        // GET: Orgins
        public async Task<IActionResult> Index()
        {
            var eFPizzaContext = _context.Orgins.Include(o => o.Pizza).OrderBy(o => o.Pizza.Name);
            return View(await eFPizzaContext.ToListAsync());
        }

        // GET: Orgins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgins = await _context.Orgins
                .Include(o => o.Pizza)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (orgins == null)
            {
                return NotFound();
            }

            return View(orgins);
        }

        // GET: Orgins/Create
        public IActionResult Create()
        {
            ViewData["PizzaId"] = new SelectList(_context.Pizzas.Where(x => x.Orgins.PizzaId != x.Id).OrderBy(p => p.Name), "Id", "Name");
            return View();
        }

        // POST: Orgins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,City,Country,Date,PizzaId")] Orgins orgins)
        {
            if (ModelState.IsValid)
            {
                if (!OrginsPizzaIdExists(orgins))
                {
                    _context.Add(orgins);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            ViewData["PizzaId"] = new SelectList(_context.Pizzas.Where(x => x.Orgins.PizzaId != x.Id).OrderBy(p => p.Name), "Id", "Name", orgins.PizzaId);
            return View(orgins);
        }

        // GET: Orgins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgins = await _context.Orgins.SingleOrDefaultAsync(m => m.Id == id);
            if (orgins == null)
            {
                return NotFound();
            }
            ViewData["PizzaId"] = new SelectList(_context.Pizzas.OrderBy(p => p.Name), "Id", "Name", orgins.PizzaId);
            return View(orgins);
        }

        // POST: Orgins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,City,Country,Date,PizzaId")] Orgins orgins)
        {
            if (id != orgins.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orgins);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrginsExists(orgins.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["PizzaId"] = new SelectList(_context.Pizzas.OrderBy(p => p.Name), "Id", "Name", orgins.PizzaId);
            return View(orgins);
        }

        // GET: Orgins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgins = await _context.Orgins
                .Include(o => o.Pizza)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (orgins == null)
            {
                return NotFound();
            }

            return View(orgins);
        }

        // POST: Orgins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orgins = await _context.Orgins.SingleOrDefaultAsync(m => m.Id == id);
            _context.Orgins.Remove(orgins);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool OrginsExists(int id)
        {
            return _context.Orgins.Any(e => e.Id == id);
        }

        private bool OrginsPizzaIdExists(Orgins origins)
        {
            return _context.Orgins.Any(o => o.PizzaId == origins.PizzaId);
        }
    }
}
