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
    public class CAT_Tipo_De_MaterialController : Controller
    {
        private readonly AppDbContext _context;

        public CAT_Tipo_De_MaterialController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CAT_Tipo_De_Material
        public async Task<IActionResult> Mantenimiento()
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            return _context.CAT_Tipos_De_Materiales != null ? 
                          View(await _context.CAT_Tipos_De_Materiales.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.CAT_Tipos_De_Materiales'  is null.");
        }

        // GET: CAT_Tipo_De_Material/Details/5
        public async Task<IActionResult> Detalles(int? id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (id == null || _context.CAT_Tipos_De_Materiales == null)
            {
                return NotFound();
            }

            var cAT_Tipo_De_Material = await _context.CAT_Tipos_De_Materiales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cAT_Tipo_De_Material == null)
            {
                return NotFound();
            }
            
            return View(cAT_Tipo_De_Material);
        }

        // GET: CAT_Tipo_De_Material/Create
        public IActionResult Crear()
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            return View();
        }

        // POST: CAT_Tipo_De_Material/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("Id,CH_Nombre,CH_Descripcion,CH_Tratamiento")] CAT_Tipo_De_Material cAT_Tipo_De_Material)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (ModelState.IsValid)
            {
                _context.Add(cAT_Tipo_De_Material);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Mantenimiento));
            }
            
            return View(cAT_Tipo_De_Material);
        }

        // GET: CAT_Tipo_De_Material/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (id == null || _context.CAT_Tipos_De_Materiales == null)
            {
                return NotFound();
            }

            var cAT_Tipo_De_Material = await _context.CAT_Tipos_De_Materiales.FindAsync(id);
            if (cAT_Tipo_De_Material == null)
            {
                return NotFound();
            }

            return View(cAT_Tipo_De_Material);
        }

        // POST: CAT_Tipo_De_Material/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,CH_Nombre,CH_Descripcion,CH_Tratamiento")] CAT_Tipo_De_Material cAT_Tipo_De_Material)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (id != cAT_Tipo_De_Material.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cAT_Tipo_De_Material);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CAT_Tipo_De_MaterialExists(cAT_Tipo_De_Material.Id))
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
            
            return View(cAT_Tipo_De_Material);
        }

        // GET: CAT_Tipo_De_Material/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (id == null || _context.CAT_Tipos_De_Materiales == null)
            {
                return NotFound();
            }

            var cAT_Tipo_De_Material = await _context.CAT_Tipos_De_Materiales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cAT_Tipo_De_Material == null)
            {
                return NotFound();
            }

            return View(cAT_Tipo_De_Material);
        }

        // POST: CAT_Tipo_De_Material/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (_context.CAT_Tipos_De_Materiales == null)
            {
                return Problem("Entity set 'AppDbContext.CAT_Tipos_De_Materiales'  is null.");
            }
            var cAT_Tipo_De_Material = await _context.CAT_Tipos_De_Materiales.FindAsync(id);
            if (cAT_Tipo_De_Material != null)
            {
                _context.CAT_Tipos_De_Materiales.Remove(cAT_Tipo_De_Material);
            }
            
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Mantenimiento));
        }

        private bool CAT_Tipo_De_MaterialExists(int id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            return (_context.CAT_Tipos_De_Materiales?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
