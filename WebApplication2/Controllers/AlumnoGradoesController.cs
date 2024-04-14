using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AlumnoGradoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlumnoGradoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AlumnoGradoes
        public async Task<IActionResult> Index()
        {
              return _context.AlumnoGrados != null ? 
                          View(await _context.AlumnoGrados.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AlumnoGrados'  is null.");
        }

        // GET: AlumnoGradoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AlumnoGrados == null)
            {
                return NotFound();
            }

            var alumnoGrado = await _context.AlumnoGrados
                .FirstOrDefaultAsync(m => m.IdAlumnoGrado == id);
            if (alumnoGrado == null)
            {
                return NotFound();
            }

            return View(alumnoGrado);
        }

        // GET: AlumnoGradoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlumnoGradoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlumnoGrado,IdAlumno,GradoId,Seccion")] AlumnoGrado alumnoGrado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumnoGrado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alumnoGrado);
        }

        // GET: AlumnoGradoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AlumnoGrados == null)
            {
                return NotFound();
            }

            var alumnoGrado = await _context.AlumnoGrados.FindAsync(id);
            if (alumnoGrado == null)
            {
                return NotFound();
            }
            return View(alumnoGrado);
        }

        // POST: AlumnoGradoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAlumnoGrado,IdAlumno,GradoId,Seccion")] AlumnoGrado alumnoGrado)
        {
            if (id != alumnoGrado.IdAlumnoGrado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumnoGrado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnoGradoExists(alumnoGrado.IdAlumnoGrado))
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
            return View(alumnoGrado);
        }

        // GET: AlumnoGradoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AlumnoGrados == null)
            {
                return NotFound();
            }

            var alumnoGrado = await _context.AlumnoGrados
                .FirstOrDefaultAsync(m => m.IdAlumnoGrado == id);
            if (alumnoGrado == null)
            {
                return NotFound();
            }

            return View(alumnoGrado);
        }

        // POST: AlumnoGradoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AlumnoGrados == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AlumnoGrados'  is null.");
            }
            var alumnoGrado = await _context.AlumnoGrados.FindAsync(id);
            if (alumnoGrado != null)
            {
                _context.AlumnoGrados.Remove(alumnoGrado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnoGradoExists(int id)
        {
          return (_context.AlumnoGrados?.Any(e => e.IdAlumnoGrado == id)).GetValueOrDefault();
        }
    }
}
