using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdopcionWeb.Models;

namespace AdopcionWeb.Controllers
{
    public class MascotumsController : Controller
    {
        private readonly mascotasContext _context;

        public MascotumsController(mascotasContext context)
        {
            _context = context;
        }

        // GET: Mascotums
        public async Task<IActionResult> Index()
        {
              return _context.Mascota != null ? 
                          View(await _context.Mascota.ToListAsync()) :
                          Problem("Entity set 'mascotasContext.Mascota'  is null.");
        }

        // GET: Mascotums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mascota == null)
            {
                return NotFound();
            }

            var mascotum = await _context.Mascota
                .FirstOrDefaultAsync(m => m.IdMascota == id);
            if (mascotum == null)
            {
                return NotFound();
            }

            return View(mascotum);
        }

        // GET: Mascotums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mascotums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMascota,Nombre,Descripcion,TiempoRescatada")] Mascotum mascotum)
        {
            var existingMascotum = await _context.Mascota.FirstOrDefaultAsync(p => p.IdMascota == mascotum.IdMascota);
            if(existingMascotum != null)
            {
                ModelState.AddModelError("IdMascota", "Este id ya ha sido agregado");
                return View(mascotum);
            }
            if (ModelState.IsValid)
            {
                _context.Add(mascotum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mascotum);
        }

        // GET: Mascotums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mascota == null)
            {
                return NotFound();
            }

            var mascotum = await _context.Mascota.FindAsync(id);
            if (mascotum == null)
            {
                return NotFound();
            }
            return View(mascotum);
        }

        // POST: Mascotums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMascota,Nombre,Descripcion,TiempoRescatada")] Mascotum mascotum)
        {
            if (id != mascotum.IdMascota)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mascotum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MascotumExists(mascotum.IdMascota))
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
            return View(mascotum);
        }

        // GET: Mascotums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mascota == null)
            {
                return NotFound();
            }

            var mascotum = await _context.Mascota
                .FirstOrDefaultAsync(m => m.IdMascota == id);
            if (mascotum == null)
            {
                return NotFound();
            }

            return View(mascotum);
        }

        // POST: Mascotums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mascota == null)
            {
                return Problem("Entity set 'mascotasContext.Mascota'  is null.");
            }
            var mascotum = await _context.Mascota.FindAsync(id);
            if (mascotum != null)
            {
                _context.Mascota.Remove(mascotum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MascotumExists(int id)
        {
          return (_context.Mascota?.Any(e => e.IdMascota == id)).GetValueOrDefault();
        }
    }
}
