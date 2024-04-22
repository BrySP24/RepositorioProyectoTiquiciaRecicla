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
    public class TBL_AnuncioController : Controller
    {
        private readonly AppDbContext _context;

        public TBL_AnuncioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TBL_Anuncio
        public async Task<IActionResult> Mantenimiento()
        {
            var appDbContext = _context.TBL_Anuncios.Include(t => t.CAT_Centros_De_Acopio);
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            return View(await appDbContext.ToListAsync());
        }

        // GET: TBL_Anuncio/Details/5
        public async Task<IActionResult> Detalles(int? id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (id == null || _context.TBL_Anuncios == null)
            {
                return NotFound();
            }

            var tBL_Anuncio = await _context.TBL_Anuncios
                .Include(t => t.CAT_Centros_De_Acopio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tBL_Anuncio == null)
            {
                return NotFound();
            }
            
            return View(tBL_Anuncio);
        }

        // GET: TBL_Anuncio/Create
        public IActionResult Crear()
        {
            ViewData["CAT_Centro_De_AcopioId"] = new SelectList(_context.CAT_Centros_De_Acopio, "Id", "CH_Nombre");
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            return View();
        }

        // POST: TBL_Anuncio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("Id,CH_Titulo,IMG_Banner,CH_Descripcion,CAT_Centro_De_AcopioId")] TBL_Anuncio tBL_Anuncio)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (ModelState.IsValid)
            {
                _context.Add(tBL_Anuncio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Mantenimiento));
            }
            ViewData["CAT_Centro_De_AcopioId"] = new SelectList(_context.CAT_Centros_De_Acopio, "Id", "CH_Nombre", tBL_Anuncio.CAT_Centro_De_AcopioId);
            
            return View(tBL_Anuncio);
        }

        // GET: TBL_Anuncio/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (id == null || _context.TBL_Anuncios == null)
            {
                return NotFound();
            }

            var tBL_Anuncio = await _context.TBL_Anuncios.FindAsync(id);
            if (tBL_Anuncio == null)
            {
                return NotFound();
            }
            ViewData["CAT_Centro_De_AcopioId"] = new SelectList(_context.CAT_Centros_De_Acopio, "Id", "CH_Nombre", tBL_Anuncio.CAT_Centro_De_AcopioId);
            
            return View(tBL_Anuncio);
        }

        // POST: TBL_Anuncio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,CH_Titulo,IMG_Banner,CH_Descripcion,CAT_Centro_De_AcopioId")] TBL_Anuncio tBL_Anuncio)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (id != tBL_Anuncio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tBL_Anuncio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TBL_AnuncioExists(tBL_Anuncio.Id))
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
            ViewData["CAT_Centro_De_AcopioId"] = new SelectList(_context.CAT_Centros_De_Acopio, "Id", "CH_Nombre", tBL_Anuncio.CAT_Centro_De_AcopioId);
            
            return View(tBL_Anuncio);
        }

        // GET: TBL_Anuncio/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (id == null || _context.TBL_Anuncios == null)
            {
                return NotFound();
            }

            var tBL_Anuncio = await _context.TBL_Anuncios
                .Include(t => t.CAT_Centros_De_Acopio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tBL_Anuncio == null)
            {
                return NotFound();
            }
            
            return View(tBL_Anuncio);
        }

        // POST: TBL_Anuncio/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (_context.TBL_Anuncios == null)
            {
                return Problem("Entity set 'AppDbContext.TBL_Anuncios'  is null.");
            }
            var tBL_Anuncio = await _context.TBL_Anuncios.FindAsync(id);
            if (tBL_Anuncio != null)
            {
                _context.TBL_Anuncios.Remove(tBL_Anuncio);
            }
            
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Mantenimiento));
        }

        private bool TBL_AnuncioExists(int id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            return (_context.TBL_Anuncios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
