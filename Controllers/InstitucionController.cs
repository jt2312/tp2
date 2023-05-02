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
    public class InstitucionController : Controller
    {
        private readonly EstudiantContext _context;

        public InstitucionController(EstudiantContext context)
        {
            _context = context;
        }

        // GET: Institucion
        public async Task<IActionResult> Index()
        {
              return _context.Institucion != null ? 
                          View(await _context.Institucion.ToListAsync()) :
                          Problem("Entity set 'EstudiantContext.Institucion'  is null.");
        }

        // GET: Institucion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Institucion == null)
            {
                return NotFound();
            }

            var institucion = await _context.Institucion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (institucion == null)
            {
                return NotFound();
            }

            return View(institucion);
        }

        // GET: Institucion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Institucion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Institucion institucion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(institucion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(institucion);
        }

        // GET: Institucion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Institucion == null)
            {
                return NotFound();
            }

            var institucion = await _context.Institucion.FindAsync(id);
            if (institucion == null)
            {
                return NotFound();
            }
            return View(institucion);
        }

        // POST: Institucion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Institucion institucion)
        {
            if (id != institucion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(institucion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstitucionExists(institucion.Id))
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
            return View(institucion);
        }

        // GET: Institucion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Institucion == null)
            {
                return NotFound();
            }

            var institucion = await _context.Institucion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (institucion == null)
            {
                return NotFound();
            }

            return View(institucion);
        }

        // POST: Institucion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Institucion == null)
            {
                return Problem("Entity set 'EstudiantContext.Institucion'  is null.");
            }
            var institucion = await _context.Institucion.FindAsync(id);
            if (institucion != null)
            {
                _context.Institucion.Remove(institucion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstitucionExists(int id)
        {
          return (_context.Institucion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
