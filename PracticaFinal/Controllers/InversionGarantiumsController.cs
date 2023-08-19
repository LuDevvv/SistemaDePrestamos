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
    public class InversionGarantiumsController : Controller
    {
        private readonly FinalProjectContext _context;

        public InversionGarantiumsController(FinalProjectContext context)
        {
            _context = context;
        }

        // GET: InversionGarantiums
        public async Task<IActionResult> Index()
        {
            var finalProjectContext = _context.InversionGarantia.Include(i => i.IdInversionNavigation);
            return View(await finalProjectContext.ToListAsync());
        }

        // GET: InversionGarantiums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InversionGarantia == null)
            {
                return NotFound();
            }

            var inversionGarantium = await _context.InversionGarantia
                .Include(i => i.IdInversionNavigation)
                .FirstOrDefaultAsync(m => m.IdGarantia == id);
            if (inversionGarantium == null)
            {
                return NotFound();
            }

            return View(inversionGarantium);
        }

        // GET: InversionGarantiums/Create
        public IActionResult Create()
        {
            ViewData["IdInversion"] = new SelectList(_context.Inversiones, "IdInversion", "IdInversion");
            return View();
        }

        // POST: InversionGarantiums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGarantia,Nombre,Tipo,Valor,Ubicacion,IdInversion")] InversionGarantium inversionGarantium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inversionGarantium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdInversion"] = new SelectList(_context.Inversiones, "IdInversion", "IdInversion", inversionGarantium.IdInversion);
            return View(inversionGarantium);
        }

        // GET: InversionGarantiums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InversionGarantia == null)
            {
                return NotFound();
            }

            var inversionGarantium = await _context.InversionGarantia.FindAsync(id);
            if (inversionGarantium == null)
            {
                return NotFound();
            }
            ViewData["IdInversion"] = new SelectList(_context.Inversiones, "IdInversion", "IdInversion", inversionGarantium.IdInversion);
            return View(inversionGarantium);
        }

        // POST: InversionGarantiums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGarantia,Nombre,Tipo,Valor,Ubicacion,IdInversion")] InversionGarantium inversionGarantium)
        {
            if (id != inversionGarantium.IdGarantia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inversionGarantium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InversionGarantiumExists(inversionGarantium.IdGarantia))
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
            ViewData["IdInversion"] = new SelectList(_context.Inversiones, "IdInversion", "IdInversion", inversionGarantium.IdInversion);
            return View(inversionGarantium);
        }

        // GET: InversionGarantiums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InversionGarantia == null)
            {
                return NotFound();
            }

            var inversionGarantium = await _context.InversionGarantia
                .Include(i => i.IdInversionNavigation)
                .FirstOrDefaultAsync(m => m.IdGarantia == id);
            if (inversionGarantium == null)
            {
                return NotFound();
            }

            return View(inversionGarantium);
        }

        // POST: InversionGarantiums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InversionGarantia == null)
            {
                return Problem("Entity set 'FinalProjectContext.InversionGarantia'  is null.");
            }
            var inversionGarantium = await _context.InversionGarantia.FindAsync(id);
            if (inversionGarantium != null)
            {
                _context.InversionGarantia.Remove(inversionGarantium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InversionGarantiumExists(int id)
        {
          return _context.InversionGarantia.Any(e => e.IdGarantia == id);
        }
    }
}
