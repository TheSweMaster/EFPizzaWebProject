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
    public class IngredientsController : Controller
    {
        private readonly EFPizzaContext _context;

        public IngredientsController(EFPizzaContext context)
        {
            _context = context;    
        }

        // GET: Ingredients
        public async Task<IActionResult> Index()
        {
            var listOfIngredients = await _context.Ingredients.OrderBy(i => i.Name).ToListAsync();
            return View(listOfIngredients);
        }

        // GET: Ingredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredients = await _context.Ingredients
                .SingleOrDefaultAsync(m => m.Id == id);

            var listOfPizzas = await _context.PizzaIngredients.Where(x => x.IngredientId == id).Select(x => x.Pizza.Name).ToListAsync();

            ViewBag.PizzaIngredients = listOfPizzas;

            if (ingredients == null)
            {
                return NotFound();
            }

            return View(ingredients);
        }

        // GET: Ingredients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gluten,Name")] Ingredients ingredients, string type)
        {
            if (ModelState.IsValid)
            {
                ingredients.Type = SetingredientsType(type);
                _context.Add(ingredients);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ingredients);
        }

        private Types SetingredientsType(string type)
        {
            if (type == "Meat")
            {
                return Types.Meat;
            }
            else if (type == "Vegetable")
            {
                return Types.Vegetable;
            }
            else if (type == "Fruit")
            {
                return Types.Fruit;
            }
            else
            {
                return Types.Other;
            }
        }

        // GET: Ingredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredients = await _context.Ingredients.SingleOrDefaultAsync(m => m.Id == id);
            if (ingredients == null)
            {
                return NotFound();
            }
            return View(ingredients);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gluten,Name")] Ingredients ingredients, string type)
        {
            if (id != ingredients.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ingredients.Type = SetingredientsType(type);
                    _context.Update(ingredients);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientsExists(ingredients.Id))
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
            return View(ingredients);
        }

        // GET: Ingredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredients = await _context.Ingredients
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ingredients == null)
            {
                return NotFound();
            }

            return View(ingredients);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredients = await _context.Ingredients.SingleOrDefaultAsync(m => m.Id == id);
            _context.Ingredients.Remove(ingredients);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool IngredientsExists(int id)
        {
            return _context.Ingredients.Any(e => e.Id == id);
        }
    }
}
