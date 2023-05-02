using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tp2.Data;
using Tp2.Models;

namespace Tp2.Controllers
{
    public class DireccionController : Controller
    {
        private readonly EstudiantContext _context;

        public DireccionController(EstudiantContext context)
        {
            _context = context;
        }

        // GET: Direccion
        public async Task<IActionResult> Index()
        {
              return _context.Direccion != null ? 
                          View(await _context.Direccion.ToListAsync()) :
                          Problem("Entity set 'EstudiantContext.Direccion'  is null.");
        }

        // GET: Direccion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Direccion == null)
            {
                return NotFound();
            }

            var direccion = await _context.Direccion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }

        // GET: Direccion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Direccion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Calle,EstudianteId")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(direccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(direccion);
        }

        // GET: Direccion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Direccion == null)
            {
                return NotFound();
            }

            var direccion = await _context.Direccion.FindAsync(id);
            if (direccion == null)
            {
                return NotFound();
            }
            return View(direccion);
        }

        // POST: Direccion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Calle,EstudianteId")] Direccion direccion)
        {
            if (id != direccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(direccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DireccionExists(direccion.Id))
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
            return View(direccion);
        }

        // GET: Direccion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Direccion == null)
            {
                return NotFound();
            }

            var direccion = await _context.Direccion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }

        // POST: Direccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Direccion == null)
            {
                return Problem("Entity set 'EstudiantContext.Direccion'  is null.");
            }
            var direccion = await _context.Direccion.FindAsync(id);
            if (direccion != null)
            {
                _context.Direccion.Remove(direccion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DireccionExists(int id)
        {
          return (_context.Direccion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
