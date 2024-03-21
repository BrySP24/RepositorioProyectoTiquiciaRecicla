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
    public class TBL_EventoController : Controller
    {
        private readonly AppDbContext _context;

        public TBL_EventoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TBL_Evento
        public async Task<IActionResult> Mantenimiento()
        {
            var appDbContext = _context.TBL_Eventos.Include(t => t.CAT_Empresas_Recolectoras);
            return View(await appDbContext.ToListAsync());
        }

        // GET: TBL_Evento/Details/5
        public async Task<IActionResult> Detalles(int? id)
        {
            if (id == null || _context.TBL_Eventos == null)
            {
                return NotFound();
            }

            var tBL_Evento = await _context.TBL_Eventos
                .Include(t => t.CAT_Empresas_Recolectoras)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tBL_Evento == null)
            {
                return NotFound();
            }

            return View(tBL_Evento);
        }

        // GET: TBL_Evento/Create
        public IActionResult Crear()
        {
            ViewData["CAT_Empresa_RecolectoraId"] = new SelectList(_context.CAT_Empresas_Recolectoras, "Id", "CH_Nombre");
            return View();
        }

        // POST: TBL_Evento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("Id,CH_Nombre,CH_Descripcion,DTI_Inicio,DTI_Fin,CH_Premio,CAT_Empresa_RecolectoraId")] TBL_Evento tBL_Evento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tBL_Evento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Mantenimiento));
            }
            ViewData["CAT_Empresa_RecolectoraId"] = new SelectList(_context.CAT_Empresas_Recolectoras, "Id", "CH_Nombre", tBL_Evento.CAT_Empresa_RecolectoraId);
            return View(tBL_Evento);
        }

        // GET: TBL_Evento/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.TBL_Eventos == null)
            {
                return NotFound();
            }

            var tBL_Evento = await _context.TBL_Eventos.FindAsync(id);
            if (tBL_Evento == null)
            {
                return NotFound();
            }
            ViewData["CAT_Empresa_RecolectoraId"] = new SelectList(_context.CAT_Empresas_Recolectoras, "Id", "CH_Nombre", tBL_Evento.CAT_Empresa_RecolectoraId);
            return View(tBL_Evento);
        }

        // POST: TBL_Evento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,CH_Nombre,CH_Descripcion,DTI_Inicio,DTI_Fin,CH_Premio,CAT_Empresa_RecolectoraId")] TBL_Evento tBL_Evento)
        {
            if (id != tBL_Evento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tBL_Evento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TBL_EventoExists(tBL_Evento.Id))
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
            ViewData["CAT_Empresa_RecolectoraId"] = new SelectList(_context.CAT_Empresas_Recolectoras, "Id", "CH_Nombre", tBL_Evento.CAT_Empresa_RecolectoraId);
            return View(tBL_Evento);
        }

        // GET: TBL_Evento/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.TBL_Eventos == null)
            {
                return NotFound();
            }

            var tBL_Evento = await _context.TBL_Eventos
                .Include(t => t.CAT_Empresas_Recolectoras)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tBL_Evento == null)
            {
                return NotFound();
            }

            return View(tBL_Evento);
        }

        // POST: TBL_Evento/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TBL_Eventos == null)
            {
                return Problem("Entity set 'AppDbContext.TBL_Eventos'  is null.");
            }
            var tBL_Evento = await _context.TBL_Eventos.FindAsync(id);
            if (tBL_Evento != null)
            {
                _context.TBL_Eventos.Remove(tBL_Evento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Mantenimiento));
        }

        private bool TBL_EventoExists(int id)
        {
          return (_context.TBL_Eventos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
