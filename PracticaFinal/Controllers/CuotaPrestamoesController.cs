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
    public class CuotaPrestamoesController : Controller
    {
        private readonly FinalProjectContext _context;

        public CuotaPrestamoesController(FinalProjectContext context)
        {
            _context = context;
        }

        // GET: CuotaPrestamoes
        public async Task<IActionResult> Index()
        {
            var finalProjectContext = _context.CuotaPrestamos.Include(c => c.IdPrestamoNavigation).Include(c => c.TipoTransaccionNavigation);
            return View(await finalProjectContext.ToListAsync());
        }

        // GET: CuotaPrestamoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CuotaPrestamos == null)
            {
                return NotFound();
            }

            var cuotaPrestamo = await _context.CuotaPrestamos
                .Include(c => c.IdPrestamoNavigation)
                .Include(c => c.TipoTransaccionNavigation)
                .FirstOrDefaultAsync(m => m.CodCuota == id);
            if (cuotaPrestamo == null)
            {
                return NotFound();
            }

            return View(cuotaPrestamo);
        }

        // GET: CuotaPrestamoes/Create
        public IActionResult Create()
        {
            ViewData["IdPrestamo"] = new SelectList(_context.Prestamos, "Idprestamo", "Idprestamo");
            ViewData["TipoTransaccion"] = new SelectList(_context.TipoPagos, "IdTipo", "IdTipo");
            return View();
        }

        // POST: CuotaPrestamoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodCuota,FechaPlanificada,Monto,FechaRealizada,CodComprobante,IdPrestamo,TipoTransaccion")] CuotaPrestamo cuotaPrestamo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuotaPrestamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPrestamo"] = new SelectList(_context.Prestamos, "Idprestamo", "Idprestamo", cuotaPrestamo.IdPrestamo);
            ViewData["TipoTransaccion"] = new SelectList(_context.TipoPagos, "IdTipo", "IdTipo", cuotaPrestamo.TipoTransaccion);
            return View(cuotaPrestamo);
        }

        // GET: CuotaPrestamoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CuotaPrestamos == null)
            {
                return NotFound();
            }

            var cuotaPrestamo = await _context.CuotaPrestamos.FindAsync(id);
            if (cuotaPrestamo == null)
            {
                return NotFound();
            }
            ViewData["IdPrestamo"] = new SelectList(_context.Prestamos, "Idprestamo", "Idprestamo", cuotaPrestamo.IdPrestamo);
            ViewData["TipoTransaccion"] = new SelectList(_context.TipoPagos, "IdTipo", "IdTipo", cuotaPrestamo.TipoTransaccion);
            return View(cuotaPrestamo);
        }

        // POST: CuotaPrestamoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodCuota,FechaPlanificada,Monto,FechaRealizada,CodComprobante,IdPrestamo,TipoTransaccion")] CuotaPrestamo cuotaPrestamo)
        {
            if (id != cuotaPrestamo.CodCuota)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuotaPrestamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuotaPrestamoExists(cuotaPrestamo.CodCuota))
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
            ViewData["IdPrestamo"] = new SelectList(_context.Prestamos, "Idprestamo", "Idprestamo", cuotaPrestamo.IdPrestamo);
            ViewData["TipoTransaccion"] = new SelectList(_context.TipoPagos, "IdTipo", "IdTipo", cuotaPrestamo.TipoTransaccion);
            return View(cuotaPrestamo);
        }

        // GET: CuotaPrestamoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CuotaPrestamos == null)
            {
                return NotFound();
            }

            var cuotaPrestamo = await _context.CuotaPrestamos
                .Include(c => c.IdPrestamoNavigation)
                .Include(c => c.TipoTransaccionNavigation)
                .FirstOrDefaultAsync(m => m.CodCuota == id);
            if (cuotaPrestamo == null)
            {
                return NotFound();
            }

            return View(cuotaPrestamo);
        }

        // POST: CuotaPrestamoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CuotaPrestamos == null)
            {
                return Problem("Entity set 'FinalProjectContext.CuotaPrestamos'  is null.");
            }
            var cuotaPrestamo = await _context.CuotaPrestamos.FindAsync(id);
            if (cuotaPrestamo != null)
            {
                _context.CuotaPrestamos.Remove(cuotaPrestamo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuotaPrestamoExists(int id)
        {
          return _context.CuotaPrestamos.Any(e => e.CodCuota == id);
        }
    }
}
