using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using ProyectoTiquiciaRecicla.Data;
using ProyectoTiquiciaRecicla.Models;
using ProyectoTiquiciaRecicla.Utilidades;

namespace ProyectoTiquiciaRecicla.Controllers
{
    public class TBL_UsuarioController : Controller
    {
        private readonly AppDbContext _context;

        public TBL_UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TBL_Usuario
        public async Task<IActionResult> Mantenimiento()
        {
            var appDbContext = _context.TBL_Usuarios.Include(t => t.CAT_Provincias)
                                                    .Include(r => r.CAT_Roles);

            return View(await appDbContext.ToListAsync());
        }
        
        // GET: TBL_Usuario/Details/5
        public async Task<IActionResult> Detalles(int? id)
        {
            if (id == null || _context.TBL_Usuarios == null)
            {
                return NotFound();
            }

            var tBL_Usuario = await _context.TBL_Usuarios
                .Include(t => t.CAT_Provincias)
                 .Include(r => r.CAT_Roles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tBL_Usuario == null)
            {
                return NotFound();
            }

            return View(tBL_Usuario);
        }

        // GET: TBL_Usuario/Create
        public IActionResult Crear()
        {
            ViewData["CAT_ProvinciaId"] = new SelectList(_context.CAT_Provincias, "Id", "CH_Nombre");
            ViewData["CAT_RolId"] = new SelectList(_context.CAT_Roles, "Id", "CH_Nombre");
            return View();
        }

        // POST: TBL_Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("Id,CH_Nombre,CH_Apellido_1,CH_apellido_2,CH_Correo,CH_Clave,CH_Telefono,CH_Direccion,CAT_ProvinciaId,CAT_RolId")] TBL_Usuario tBL_Usuario)
        {
            if (ModelState.IsValid)
            {
                // Hash de la contraseña antes de guardarla
                tBL_Usuario.CH_Clave = PasswordHasher.HashPassword(tBL_Usuario.CH_Clave);

                _context.Add(tBL_Usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Mantenimiento));
            }
            ViewData["CAT_ProvinciaId"] = new SelectList(_context.CAT_Provincias, "Id", "CH_Nombre", tBL_Usuario.CAT_ProvinciaId);
            return View(tBL_Usuario);
        }

        // GET: TBL_Usuario/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.TBL_Usuarios == null)
            {
                return NotFound();
            }

            var tBL_Usuario = await _context.TBL_Usuarios.FindAsync(id);
            if (tBL_Usuario == null)
            {
                return NotFound();
            }
            ViewData["CAT_ProvinciaId"] = new SelectList(_context.CAT_Provincias, "Id", "CH_Nombre", tBL_Usuario.CAT_ProvinciaId);
            ViewData["CAT_RolId"] = new SelectList(_context.CAT_Roles, "Id", "CH_Nombre", tBL_Usuario.CAT_RolId);
            return View(tBL_Usuario);
        }

        // POST: TBL_Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,CH_Nombre,CH_Apellido_1,CH_apellido_2,CH_Correo,CH_Clave,CH_Telefono,CH_Direccion,CAT_ProvinciaId,CAT_RolId")] TBL_Usuario tBL_Usuario)
        {
            if (id != tBL_Usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Hash de la contraseña antes de guardarla
                    tBL_Usuario.CH_Clave = PasswordHasher.HashPassword(tBL_Usuario.CH_Clave);

                    _context.Update(tBL_Usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TBL_UsuarioExists(tBL_Usuario.Id))
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
            ViewData["CAT_ProvinciaId"] = new SelectList(_context.CAT_Provincias, "Id", "CH_Nombre", tBL_Usuario.CAT_ProvinciaId);
            return View(tBL_Usuario);
        }

        // GET: TBL_Usuario/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.TBL_Usuarios == null)
            {
                return NotFound();
            }

            var tBL_Usuario = await _context.TBL_Usuarios
                .Include(t => t.CAT_Provincias)
                .Include(r => r.CAT_Roles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tBL_Usuario == null)
            {
                return NotFound();
            }

            return View(tBL_Usuario);
        }

        // POST: TBL_Usuario/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TBL_Usuarios == null)
            {
                return Problem("Entity set 'AppDbContext.TBL_Usuarios'  is null.");
            }
            var tBL_Usuario = await _context.TBL_Usuarios.FindAsync(id);
            if (tBL_Usuario != null)
            {
                _context.TBL_Usuarios.Remove(tBL_Usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Mantenimiento));
        }

        private bool TBL_UsuarioExists(int id)
        {
          return (_context.TBL_Usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
