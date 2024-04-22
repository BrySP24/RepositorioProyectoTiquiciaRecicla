using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoTiquiciaRecicla.Data;
using ProyectoTiquiciaRecicla.Models;
using static ProyectoTiquiciaRecicla.Controllers.HomeController;

namespace ProyectoTiquiciaRecicla.Controllers
{
    public class TBL_Zona_de_RecolectaController : Controller
    {
        private readonly AppDbContext _context;

        public TBL_Zona_de_RecolectaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TBL_Zona_de_Recolecta
        public async Task<IActionResult> Mantenimiento()
        {
            var appDbContext = _context.TBL_Zonas_de_Recolecta.Include(t => t.CAT_Centros_De_Acopio);
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            return View(await appDbContext.ToListAsync());
        }

        // GET: TBL_Zona_de_Recolecta/Details/5
        public async Task<IActionResult> Detalles(int? id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (id == null || _context.TBL_Zonas_de_Recolecta == null)
            {
                return NotFound();
            }

            var tBL_Zona_de_Recolecta = await _context.TBL_Zonas_de_Recolecta
                .Include(t => t.CAT_Centros_De_Acopio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tBL_Zona_de_Recolecta == null)
            {
                return NotFound();
            }
            
            return View(tBL_Zona_de_Recolecta);
        }

        // GET: TBL_Zona_de_Recolecta/Create
        public IActionResult Crear()
        {
            ViewData["CAT_Centro_De_AcopioId"] = new SelectList(_context.CAT_Centros_De_Acopio, "Id", "CH_Nombre");
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            return View();
        }

        // POST: TBL_Zona_de_Recolecta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("Id,CH_Direccion,DEC_Latitud,DEC_Longitud,DTI_Inicio,DTI_Fin,CH_Horario,CAT_Centro_De_AcopioId")] TBL_Zona_de_Recolecta tBL_Zona_de_Recolecta)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (ModelState.IsValid)
            {
                _context.Add(tBL_Zona_de_Recolecta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Mantenimiento));
            }
            ViewData["CAT_Centro_De_AcopioId"] = new SelectList(_context.CAT_Centros_De_Acopio, "Id", "CH_Nombre", tBL_Zona_de_Recolecta.CAT_Centro_De_AcopioId);
            
            return View(tBL_Zona_de_Recolecta);
        }

        // GET: TBL_Zona_de_Recolecta/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (id == null || _context.TBL_Zonas_de_Recolecta == null)
            {
                return NotFound();
            }

            var tBL_Zona_de_Recolecta = await _context.TBL_Zonas_de_Recolecta.FindAsync(id);
            if (tBL_Zona_de_Recolecta == null)
            {
                return NotFound();
            }
            ViewData["CAT_Centro_De_AcopioId"] = new SelectList(_context.CAT_Centros_De_Acopio, "Id", "CH_Nombre", tBL_Zona_de_Recolecta.CAT_Centro_De_AcopioId);
            
            return View(tBL_Zona_de_Recolecta);
        }

        // POST: TBL_Zona_de_Recolecta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,CH_Direccion,DEC_Latitud,DEC_Longitud,DTI_Inicio,DTI_Fin,CH_Horario,CAT_Centro_De_AcopioId")] TBL_Zona_de_Recolecta tBL_Zona_de_Recolecta)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (id != tBL_Zona_de_Recolecta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tBL_Zona_de_Recolecta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TBL_Zona_de_RecolectaExists(tBL_Zona_de_Recolecta.Id))
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
            ViewData["CAT_Centro_De_AcopioId"] = new SelectList(_context.CAT_Centros_De_Acopio, "Id", "CH_Nombre", tBL_Zona_de_Recolecta.CAT_Centro_De_AcopioId);
            
            return View(tBL_Zona_de_Recolecta);
        }

        // GET: TBL_Zona_de_Recolecta/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (id == null || _context.TBL_Zonas_de_Recolecta == null)
            {
                return NotFound();
            }

            var tBL_Zona_de_Recolecta = await _context.TBL_Zonas_de_Recolecta
                .Include(t => t.CAT_Centros_De_Acopio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tBL_Zona_de_Recolecta == null)
            {
                return NotFound();
            }

            return View(tBL_Zona_de_Recolecta);
        }

        // POST: TBL_Zona_de_Recolecta/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (_context.TBL_Zonas_de_Recolecta == null)
            {
                return Problem("Entity set 'AppDbContext.TBL_Zonas_de_Recolecta'  is null.");
            }
            var tBL_Zona_de_Recolecta = await _context.TBL_Zonas_de_Recolecta.FindAsync(id);
            if (tBL_Zona_de_Recolecta != null)
            {
                _context.TBL_Zonas_de_Recolecta.Remove(tBL_Zona_de_Recolecta);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Mantenimiento));
        }

        private bool TBL_Zona_de_RecolectaExists(int id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            return (_context.TBL_Zonas_de_Recolecta?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

}


