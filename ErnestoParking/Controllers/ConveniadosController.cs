using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ErnestoParking.Data;
using ErnestoParking.Models;

namespace ErnestoParking.Controllers
{
    public class ConveniadosController : Controller
    {
        private readonly ErnestoParkingContext _context;

        public ConveniadosController(ErnestoParkingContext context)
        {
            _context = context;
        }

        // GET: Conveniados
        public async Task<IActionResult> Index()
        {
              return View(await _context.Conveniado.ToListAsync());
        }

        // GET: Conveniados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Conveniado == null)
            {
                return NotFound();
            }

            var conveniado = await _context.Conveniado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conveniado == null)
            {
                return NotFound();
            }

            return View(conveniado);
        }

        // GET: Conveniados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conveniados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Conveniado conveniado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conveniado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conveniado);
        }

        // GET: Conveniados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Conveniado == null)
            {
                return NotFound();
            }

            var conveniado = await _context.Conveniado.FindAsync(id);
            if (conveniado == null)
            {
                return NotFound();
            }
            return View(conveniado);
        }

        // POST: Conveniados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Conveniado conveniado)
        {
            if (id != conveniado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conveniado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConveniadoExists(conveniado.Id))
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
            return View(conveniado);
        }

        // GET: Conveniados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Conveniado == null)
            {
                return NotFound();
            }

            var conveniado = await _context.Conveniado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conveniado == null)
            {
                return NotFound();
            }

            return View(conveniado);
        }

        // POST: Conveniados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Conveniado == null)
            {
                return Problem("Entity set 'ErnestoParkingContext.Conveniado'  is null.");
            }
            var conveniado = await _context.Conveniado.FindAsync(id);
            if (conveniado != null)
            {
                _context.Conveniado.Remove(conveniado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConveniadoExists(int id)
        {
          return _context.Conveniado.Any(e => e.Id == id);
        }
    }
}
