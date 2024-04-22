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
    public class CAT_Empresa_RecolectoraController : Controller
    {
        private readonly AppDbContext _context;

        public CAT_Empresa_RecolectoraController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CAT_Empresa_Recolectora
        public async Task<IActionResult> Mantenimiento()
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            return _context.CAT_Empresas_Recolectoras != null ? 
                          View(await _context.CAT_Empresas_Recolectoras.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.CAT_Empresas_Recolectoras'  is null.");
        }

        // GET: CAT_Empresa_Recolectora/Details/5
        public async Task<IActionResult> Detalles(int? id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (id == null || _context.CAT_Empresas_Recolectoras == null)
            {
                return NotFound();
            }

            var cAT_Empresa_Recolectora = await _context.CAT_Empresas_Recolectoras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cAT_Empresa_Recolectora == null)
            {
                return NotFound();
            }
            
            return View(cAT_Empresa_Recolectora);
        }

        // GET: CAT_Empresa_Recolectora/Create
        public IActionResult Crear()
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            return View();
        }

        // POST: CAT_Empresa_Recolectora/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("Id,CH_Nombre,CH_Direccion,DEC_Latitud,DEC_Longitud,CH_Horario,CH_Telefono,CH_Correo_Electronico")] CAT_Empresa_Recolectora cAT_Empresa_Recolectora)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (ModelState.IsValid)
            {
                _context.Add(cAT_Empresa_Recolectora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Mantenimiento));
            }
            
            return View(cAT_Empresa_Recolectora);
        }

        // GET: CAT_Empresa_Recolectora/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (id == null || _context.CAT_Empresas_Recolectoras == null)
            {
                return NotFound();
            }

            var cAT_Empresa_Recolectora = await _context.CAT_Empresas_Recolectoras.FindAsync(id);
            if (cAT_Empresa_Recolectora == null)
            {
                return NotFound();
            }
            
            return View(cAT_Empresa_Recolectora);
        }

        // POST: CAT_Empresa_Recolectora/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,CH_Nombre,CH_Direccion,DEC_Latitud,DEC_Longitud,CH_Horario,CH_Telefono,CH_Correo_Electronico")] CAT_Empresa_Recolectora cAT_Empresa_Recolectora)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (id != cAT_Empresa_Recolectora.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cAT_Empresa_Recolectora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CAT_Empresa_RecolectoraExists(cAT_Empresa_Recolectora.Id))
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
            
            return View(cAT_Empresa_Recolectora);
        }

        // GET: CAT_Empresa_Recolectora/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (id == null || _context.CAT_Empresas_Recolectoras == null)
            {
                return NotFound();
            }

            var cAT_Empresa_Recolectora = await _context.CAT_Empresas_Recolectoras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cAT_Empresa_Recolectora == null)
            {
                return NotFound();
            }
            
            return View(cAT_Empresa_Recolectora);
        }

        // POST: CAT_Empresa_Recolectora/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (_context.CAT_Empresas_Recolectoras == null)
            {
                return Problem("Entity set 'AppDbContext.CAT_Empresas_Recolectoras'  is null.");
            }
            var cAT_Empresa_Recolectora = await _context.CAT_Empresas_Recolectoras.FindAsync(id);
            if (cAT_Empresa_Recolectora != null)
            {
                _context.CAT_Empresas_Recolectoras.Remove(cAT_Empresa_Recolectora);
            }
            
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Mantenimiento));
        }

        private bool CAT_Empresa_RecolectoraExists(int id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            return (_context.CAT_Empresas_Recolectoras?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
