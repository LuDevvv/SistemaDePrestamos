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
    public class CuotaInversionsController : Controller
    {
        private readonly FinalProjectContext _context;

        public CuotaInversionsController(FinalProjectContext context)
        {
            _context = context;
        }

        // GET: CuotaInversions
        public async Task<IActionResult> Index()
        {
            var finalProjectContext = _context.CuotaInversions.Include(c => c.IdInversionNavigation).Include(c => c.TipoTransaccionNavigation);
            return View(await finalProjectContext.ToListAsync());
        }

        // GET: CuotaInversions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CuotaInversions == null)
            {
                return NotFound();
            }

            var cuotaInversion = await _context.CuotaInversions
                .Include(c => c.IdInversionNavigation)
                .Include(c => c.TipoTransaccionNavigation)
                .FirstOrDefaultAsync(m => m.CodCuota == id);
            if (cuotaInversion == null)
            {
                return NotFound();
            }

            return View(cuotaInversion);
        }

        // GET: CuotaInversions/Create
        public IActionResult Create()
        {
            ViewData["IdInversion"] = new SelectList(_context.Inversiones, "IdInversion", "IdInversion");
            ViewData["TipoTransaccion"] = new SelectList(_context.TipoPagos, "IdTipo", "IdTipo");
            return View();
        }

        // POST: CuotaInversions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodCuota,FechaPlanificada,Monto,FechaRealizada,CodComprobante,IdInversion,TipoTransaccion")] CuotaInversion cuotaInversion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuotaInversion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdInversion"] = new SelectList(_context.Inversiones, "IdInversion", "IdInversion", cuotaInversion.IdInversion);
            ViewData["TipoTransaccion"] = new SelectList(_context.TipoPagos, "IdTipo", "IdTipo", cuotaInversion.TipoTransaccion);
            return View(cuotaInversion);
        }

        // GET: CuotaInversions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CuotaInversions == null)
            {
                return NotFound();
            }

            var cuotaInversion = await _context.CuotaInversions.FindAsync(id);
            if (cuotaInversion == null)
            {
                return NotFound();
            }
            ViewData["IdInversion"] = new SelectList(_context.Inversiones, "IdInversion", "IdInversion", cuotaInversion.IdInversion);
            ViewData["TipoTransaccion"] = new SelectList(_context.TipoPagos, "IdTipo", "IdTipo", cuotaInversion.TipoTransaccion);
            return View(cuotaInversion);
        }

        // POST: CuotaInversions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodCuota,FechaPlanificada,Monto,FechaRealizada,CodComprobante,IdInversion,TipoTransaccion")] CuotaInversion cuotaInversion)
        {
            if (id != cuotaInversion.CodCuota)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuotaInversion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuotaInversionExists(cuotaInversion.CodCuota))
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
            ViewData["IdInversion"] = new SelectList(_context.Inversiones, "IdInversion", "IdInversion", cuotaInversion.IdInversion);
            ViewData["TipoTransaccion"] = new SelectList(_context.TipoPagos, "IdTipo", "IdTipo", cuotaInversion.TipoTransaccion);
            return View(cuotaInversion);
        }

        // GET: CuotaInversions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CuotaInversions == null)
            {
                return NotFound();
            }

            var cuotaInversion = await _context.CuotaInversions
                .Include(c => c.IdInversionNavigation)
                .Include(c => c.TipoTransaccionNavigation)
                .FirstOrDefaultAsync(m => m.CodCuota == id);
            if (cuotaInversion == null)
            {
                return NotFound();
            }

            return View(cuotaInversion);
        }

        // POST: CuotaInversions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CuotaInversions == null)
            {
                return Problem("Entity set 'FinalProjectContext.CuotaInversions'  is null.");
            }
            var cuotaInversion = await _context.CuotaInversions.FindAsync(id);
            if (cuotaInversion != null)
            {
                _context.CuotaInversions.Remove(cuotaInversion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuotaInversionExists(int id)
        {
          return _context.CuotaInversions.Any(e => e.CodCuota == id);
        }
    }
}
