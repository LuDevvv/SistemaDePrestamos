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
    public class PrestamoGarantiumsController : Controller
    {
        private readonly FinalProjectContext _context;

        public PrestamoGarantiumsController(FinalProjectContext context)
        {
            _context = context;
        }

        // GET: PrestamoGarantiums
        public async Task<IActionResult> Index()
        {
            var finalProjectContext = _context.PrestamoGarantia.Include(p => p.IdPrestamoNavigation);
            return View(await finalProjectContext.ToListAsync());
        }

        // GET: PrestamoGarantiums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PrestamoGarantia == null)
            {
                return NotFound();
            }

            var prestamoGarantium = await _context.PrestamoGarantia
                .Include(p => p.IdPrestamoNavigation)
                .FirstOrDefaultAsync(m => m.IdGarantia == id);
            if (prestamoGarantium == null)
            {
                return NotFound();
            }

            return View(prestamoGarantium);
        }

        // GET: PrestamoGarantiums/Create
        public IActionResult Create()
        {
            ViewData["IdPrestamo"] = new SelectList(_context.Prestamos, "Idprestamo", "Idprestamo");
            return View();
        }

        // POST: PrestamoGarantiums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGarantia,Nombre,Tipo,Valor,Ubicacion,IdPrestamo")] PrestamoGarantium prestamoGarantium)
        {
           
                _context.PrestamoGarantia.Add(prestamoGarantium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
          
            ViewData["IdPrestamo"] = new SelectList(_context.Prestamos, "Idprestamo", "Idprestamo", prestamoGarantium.IdPrestamo);
            return View(prestamoGarantium);
        }

        // GET: PrestamoGarantiums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PrestamoGarantia == null)
            {
                return NotFound();
            }

            var prestamoGarantium = await _context.PrestamoGarantia.FindAsync(id);
            if (prestamoGarantium == null)
            {
                return NotFound();
            }
            ViewData["IdPrestamo"] = new SelectList(_context.Prestamos, "Idprestamo", "Idprestamo", prestamoGarantium.IdPrestamo);
            return View(prestamoGarantium);
        }

        // POST: PrestamoGarantiums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGarantia,Nombre,Tipo,Valor,Ubicacion,IdPrestamo")] PrestamoGarantium prestamoGarantium)
        {
            if (id != prestamoGarantium.IdGarantia)
            {
                return NotFound();
            }

           
                try
                {
                    _context.PrestamoGarantia.Update(prestamoGarantium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestamoGarantiumExists(prestamoGarantium.IdGarantia))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
           
            ViewData["IdPrestamo"] = new SelectList(_context.Prestamos, "Idprestamo", "Idprestamo", prestamoGarantium.IdPrestamo);
            return View(prestamoGarantium);
        }

        // GET: PrestamoGarantiums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PrestamoGarantia == null)
            {
                return NotFound();
            }

            var prestamoGarantium = await _context.PrestamoGarantia
                .Include(p => p.IdPrestamoNavigation)
                .FirstOrDefaultAsync(m => m.IdGarantia == id);
            if (prestamoGarantium == null)
            {
                return NotFound();
            }

            return View(prestamoGarantium);
        }

        // POST: PrestamoGarantiums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PrestamoGarantia == null)
            {
                return Problem("Entity set 'FinalProjectContext.PrestamoGarantia'  is null.");
            }
            var prestamoGarantium = await _context.PrestamoGarantia.FindAsync(id);
            if (prestamoGarantium != null)
            {
                _context.PrestamoGarantia.Remove(prestamoGarantium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestamoGarantiumExists(int id)
        {
          return _context.PrestamoGarantia.Any(e => e.IdGarantia == id);
        }
    }
}
