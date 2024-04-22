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
    public class CAT_ProvinciaController : Controller
    {
        private readonly AppDbContext _context;

        public CAT_ProvinciaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CAT_Provincia
        public async Task<IActionResult> Mantenimiento()
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            return _context.CAT_Provincias != null ? 
                          View(await _context.CAT_Provincias.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.CAT_Provincias'  is null.");
        }

        // GET: CAT_Provincia/Details/5
        public async Task<IActionResult> Detalles(int? id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (id == null || _context.CAT_Provincias == null)
            {
                return NotFound();
            }

            var cAT_Provincia = await _context.CAT_Provincias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cAT_Provincia == null)
            {
                return NotFound();
            }
            
            return View(cAT_Provincia);
        }

        // GET: CAT_Provincia/Create
        public IActionResult Crear()
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            return View();
        }

        // POST: CAT_Provincia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("Id,CH_Nombre")] CAT_Provincia cAT_Provincia)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (ModelState.IsValid)
            {
                _context.Add(cAT_Provincia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Mantenimiento));
            }
            
            return View(cAT_Provincia);
        }

        // GET: CAT_Provincia/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (id == null || _context.CAT_Provincias == null)
            {
                return NotFound();
            }

            var cAT_Provincia = await _context.CAT_Provincias.FindAsync(id);
            if (cAT_Provincia == null)
            {
                return NotFound();
            }
           
            return View(cAT_Provincia);
        }

        // POST: CAT_Provincia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,CH_Nombre")] CAT_Provincia cAT_Provincia)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (id != cAT_Provincia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cAT_Provincia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CAT_ProvinciaExists(cAT_Provincia.Id))
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
            
            return View(cAT_Provincia);
        }

        // GET: CAT_Provincia/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (id == null || _context.CAT_Provincias == null)
            {
                return NotFound();
            }

            var cAT_Provincia = await _context.CAT_Provincias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cAT_Provincia == null)
            {
                return NotFound();
            }
            
            return View(cAT_Provincia);
        }

        // POST: CAT_Provincia/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (_context.CAT_Provincias == null)
            {
                return Problem("Entity set 'AppDbContext.CAT_Provincias'  is null.");
            }
            var cAT_Provincia = await _context.CAT_Provincias.FindAsync(id);
            if (cAT_Provincia != null)
            {
                _context.CAT_Provincias.Remove(cAT_Provincia);
            }
            
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Mantenimiento));
        }

        private bool CAT_ProvinciaExists(int id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            return (_context.CAT_Provincias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
