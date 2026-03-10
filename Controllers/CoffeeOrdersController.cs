using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoffeeQueueApp.Data;
using CoffeeQueueApp.Models;

namespace CoffeeQueueApp.Controllers
{
    public class CoffeeOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoffeeOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CoffeeOrders
        public async Task<IActionResult> Index()
        {
            return View(await _context.CoffeeOrder.ToListAsync());
        }

        // GET: CoffeeOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffeeOrder = await _context.CoffeeOrder
                .FirstOrDefaultAsync(m => m.ID == id);
            if (coffeeOrder == null)
            {
                return NotFound();
            }

            return View(coffeeOrder);
        }

        // GET: CoffeeOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CoffeeOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CustomerName,Drink,Size,Milk,Sugar,Status,CreatedAt")] CoffeeOrder coffeeOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coffeeOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coffeeOrder);
        }

        // GET: CoffeeOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffeeOrder = await _context.CoffeeOrder.FindAsync(id);
            if (coffeeOrder == null)
            {
                return NotFound();
            }
            return View(coffeeOrder);
        }

        // POST: CoffeeOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CustomerName,Drink,Size,Milk,Sugar,Status,CreatedAt")] CoffeeOrder coffeeOrder)
        {
            if (id != coffeeOrder.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coffeeOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoffeeOrderExists(coffeeOrder.ID))
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
            return View(coffeeOrder);
        }

        // GET: CoffeeOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffeeOrder = await _context.CoffeeOrder
                .FirstOrDefaultAsync(m => m.ID == id);
            if (coffeeOrder == null)
            {
                return NotFound();
            }

            return View(coffeeOrder);
        }

        // POST: CoffeeOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coffeeOrder = await _context.CoffeeOrder.FindAsync(id);
            if (coffeeOrder != null)
            {
                _context.CoffeeOrder.Remove(coffeeOrder);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoffeeOrderExists(int id)
        {
            return _context.CoffeeOrder.Any(e => e.ID == id);
        }
    }
}
