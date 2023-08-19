using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaFinal.Models;

namespace PracticaFinal.Controllers
{
    public class InversionesController : Controller
    {
        private readonly FinalProjectContext _context;

        public InversionesController(FinalProjectContext context)
        {
            _context = context;
        }

        // GET: Inversiones
        public async Task<IActionResult> Index()
        {
            var finalProjectContext = _context.Inversiones.Include(i => i.IdCuentaNavigation);
            return View(await finalProjectContext.ToListAsync());
        }

        // GET: Inversiones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inversiones == null)
            {
                return NotFound();
            }

            var inversione = await _context.Inversiones
                .Include(i => i.IdCuentaNavigation)
                .FirstOrDefaultAsync(m => m.IdInversion == id);
            if (inversione == null)
            {
                return NotFound();
            }

            return View(inversione);
        }

        // GET: Inversiones/Create
        public IActionResult Create()
        {
            ViewData["IdCuenta"] = new SelectList(_context.Cuenta, "IdCuenta", "IdCuenta");
            return View();
        }

        // POST: Inversiones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInversion,Monto,FechaInicio,FechaFinal,Interes,IdCuenta")] Inversione inversione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inversione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCuenta"] = new SelectList(_context.Cuenta, "IdCuenta", "IdCuenta", inversione.IdCuenta);
            return View(inversione);
        }

        // GET: Inversiones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inversiones == null)
            {
                return NotFound();
            }

            var inversione = await _context.Inversiones.FindAsync(id);
            if (inversione == null)
            {
                return NotFound();
            }
            ViewData["IdCuenta"] = new SelectList(_context.Cuenta, "IdCuenta", "IdCuenta", inversione.IdCuenta);
            return View(inversione);
        }

        // POST: Inversiones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInversion,Monto,FechaInicio,FechaFinal,Interes,IdCuenta")] Inversione inversione)
        {
            if (id != inversione.IdInversion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inversione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InversioneExists(inversione.IdInversion))
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
            ViewData["IdCuenta"] = new SelectList(_context.Cuenta, "IdCuenta", "IdCuenta", inversione.IdCuenta);
            return View(inversione);
        }

        // GET: Inversiones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inversiones == null)
            {
                return NotFound();
            }

            var inversione = await _context.Inversiones
                .Include(i => i.IdCuentaNavigation)
                .FirstOrDefaultAsync(m => m.IdInversion == id);
            if (inversione == null)
            {
                return NotFound();
            }

            return View(inversione);
        }

        // POST: Inversiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inversiones == null)
            {
                return Problem("Entity set 'FinalProjectContext.Inversiones'  is null.");
            }
            var inversione = await _context.Inversiones.FindAsync(id);
            if (inversione != null)
            {
                _context.Inversiones.Remove(inversione);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InversioneExists(int id)
        {
          return _context.Inversiones.Any(e => e.IdInversion == id);
        }
    }
}
