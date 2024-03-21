using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoTiquiciaRecicla.Data;
using ProyectoTiquiciaRecicla.Models;

namespace ProyectoTiquiciaRecicla.Controllers
{
    public class CAT_Centro_De_AcopioController : Controller
    {
        private readonly AppDbContext _context;

        public CAT_Centro_De_AcopioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CAT_Centro_De_Acopio
        public async Task<IActionResult>  Mantenimiento()
        {
            var appDbContext = _context.CAT_Centros_De_Acopio.Include(c => c.CAT_Empresas_Recolectoras);
            return View(await appDbContext.ToListAsync());
        }

        // GET: CAT_Centro_De_Acopio/Details/5
        public async Task<IActionResult> Detalles(int? id)
        {
            if (id == null || _context.CAT_Centros_De_Acopio == null)
            {
                return NotFound();
            }

            var cAT_Centro_De_Acopio = await _context.CAT_Centros_De_Acopio
                .Include(c => c.CAT_Empresas_Recolectoras)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cAT_Centro_De_Acopio == null)
            {
                return NotFound();
            }

            return View(cAT_Centro_De_Acopio);
        }

        // GET: CAT_Centro_De_Acopio/Create
        public IActionResult Crear()
        {
            ViewData["CAT_Empresa_RecolectoraId"] = new SelectList(_context.CAT_Empresas_Recolectoras, "Id", "CH_Nombre");
            return View();
        }

        // POST: CAT_Centro_De_Acopio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("Id,CH_Nombre,CH_Direccion,DEC_Latitud,DEC_Longitud,CH_Horario,CH_Telefono,CH_Correo_Electronico,CAT_Empresa_RecolectoraId")] CAT_Centro_De_Acopio cAT_Centro_De_Acopio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cAT_Centro_De_Acopio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Mantenimiento));
            }
            ViewData["CAT_Empresa_RecolectoraId"] = new SelectList(_context.CAT_Empresas_Recolectoras, "Id", "CH_Nombre", cAT_Centro_De_Acopio.CAT_Empresa_RecolectoraId);
            return View(cAT_Centro_De_Acopio);
        }

        // GET: CAT_Centro_De_Acopio/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.CAT_Centros_De_Acopio == null)
            {
                return NotFound();
            }

            var cAT_Centro_De_Acopio = await _context.CAT_Centros_De_Acopio.FindAsync(id);
            if (cAT_Centro_De_Acopio == null)
            {
                return NotFound();
            }
            ViewData["CAT_Empresa_RecolectoraId"] = new SelectList(_context.CAT_Empresas_Recolectoras, "Id", "CH_Nombre", cAT_Centro_De_Acopio.CAT_Empresa_RecolectoraId);
            return View(cAT_Centro_De_Acopio);
        }

        // POST: CAT_Centro_De_Acopio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,CH_Nombre,CH_Direccion,DEC_Latitud,DEC_Longitud,CH_Horario,CH_Telefono,CH_Correo_Electronico,CAT_Empresa_RecolectoraId")] CAT_Centro_De_Acopio cAT_Centro_De_Acopio)
        {
            if (id != cAT_Centro_De_Acopio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cAT_Centro_De_Acopio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CAT_Centro_De_AcopioExists(cAT_Centro_De_Acopio.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Mantenimiento));
            }
            ViewData["CAT_Empresa_RecolectoraId"] = new SelectList(_context.CAT_Empresas_Recolectoras, "Id", "CH_Nombre", cAT_Centro_De_Acopio.CAT_Empresa_RecolectoraId);
            return View(cAT_Centro_De_Acopio);
        }

        // GET: CAT_Centro_De_Acopio/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.CAT_Centros_De_Acopio == null)
            {
                return NotFound();
            }

            var cAT_Centro_De_Acopio = await _context.CAT_Centros_De_Acopio
                .Include(c => c.CAT_Empresas_Recolectoras)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cAT_Centro_De_Acopio == null)
            {
                return NotFound();
            }

            return View(cAT_Centro_De_Acopio);
        }

        // POST: CAT_Centro_De_Acopio/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CAT_Centros_De_Acopio == null)
            {
                return Problem("Entity set 'AppDbContext.CAT_Centros_De_Acopio'  is null.");
            }
            var cAT_Centro_De_Acopio = await _context.CAT_Centros_De_Acopio.FindAsync(id);
            if (cAT_Centro_De_Acopio != null)
            {
                _context.CAT_Centros_De_Acopio.Remove(cAT_Centro_De_Acopio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Mantenimiento));
        }

        private bool CAT_Centro_De_AcopioExists(int id)
        {
          return (_context.CAT_Centros_De_Acopio?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
