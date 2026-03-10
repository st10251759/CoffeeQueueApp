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
    public class BaristasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BaristasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Baristas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Baristas.ToListAsync());
        }

        // GET: Baristas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barista = await _context.Baristas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barista == null)
            {
                return NotFound();
            }

            return View(barista);
        }

        // GET: Baristas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Baristas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Shift")] Barista barista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(barista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(barista);
        }

        // GET: Baristas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barista = await _context.Baristas.FindAsync(id);
            if (barista == null)
            {
                return NotFound();
            }
            return View(barista);
        }

        // POST: Baristas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Shift")] Barista barista)
        {
            if (id != barista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaristaExists(barista.Id))
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
            return View(barista);
        }

        // GET: Baristas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barista = await _context.Baristas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barista == null)
            {
                return NotFound();
            }

            return View(barista);
        }

        // POST: Baristas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var barista = await _context.Baristas.FindAsync(id);
            if (barista != null)
            {
                _context.Baristas.Remove(barista);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaristaExists(int id)
        {
            return _context.Baristas.Any(e => e.Id == id);
        }
    }
}
