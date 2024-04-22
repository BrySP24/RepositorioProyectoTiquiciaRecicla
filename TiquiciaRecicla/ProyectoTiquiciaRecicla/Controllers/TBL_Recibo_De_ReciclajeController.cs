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
    public class TBL_Recibo_De_ReciclajeController : Controller
    {
        private readonly AppDbContext _context;

        public TBL_Recibo_De_ReciclajeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TBL_Recibo_De_Reciclaje
        public async Task<IActionResult> Mantenimiento()
        {
            var appDbContext = _context.TBL_Recibos_De_Reciclaje.Include(t => t.CAT_Centros_De_Acopio).Include(t => t.CAT_Tipos_De_Materiales).Include(t => t.TBL_Usuarios);
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            return View(await appDbContext.ToListAsync());
        }

        // GET: TBL_Recibo_De_Reciclaje/Details/5
        public async Task<IActionResult> Detalles(int? id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (id == null || _context.TBL_Recibos_De_Reciclaje == null)
            {
                return NotFound();
            }

            var tBL_Recibo_De_Reciclaje = await _context.TBL_Recibos_De_Reciclaje
                .Include(t => t.CAT_Centros_De_Acopio)
                .Include(t => t.CAT_Tipos_De_Materiales)
                .Include(t => t.TBL_Usuarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tBL_Recibo_De_Reciclaje == null)
            {
                return NotFound();
            }
            
            return View(tBL_Recibo_De_Reciclaje);
        }

        // GET: TBL_Recibo_De_Reciclaje/Create
        public IActionResult Crear()
        {
            ViewData["CAT_Centro_De_AcopioId"] = new SelectList(_context.CAT_Centros_De_Acopio, "Id", "CH_Nombre");
            ViewData["CAT_Tipo_De_MaterialId"] = new SelectList(_context.CAT_Tipos_De_Materiales, "Id", "CH_Descripcion");
            ViewData["TBL_UsuarioId"] = new SelectList(_context.TBL_Usuarios, "Id", "CH_Nombre");
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            return View();
        }

        // POST: TBL_Recibo_De_Reciclaje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("Id,DTI_Fecha_Hora,DEC_Peso,CAT_Tipo_De_MaterialId,CAT_Centro_De_AcopioId,TBL_UsuarioId")] TBL_Recibo_De_Reciclaje tBL_Recibo_De_Reciclaje)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (ModelState.IsValid)
            {
                _context.Add(tBL_Recibo_De_Reciclaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Mantenimiento));
            }
            ViewData["CAT_Centro_De_AcopioId"] = new SelectList(_context.CAT_Centros_De_Acopio, "Id", "CH_Nombre", tBL_Recibo_De_Reciclaje.CAT_Centro_De_AcopioId);
            ViewData["CAT_Tipo_De_MaterialId"] = new SelectList(_context.CAT_Tipos_De_Materiales, "Id", "CH_Descripcion", tBL_Recibo_De_Reciclaje.CAT_Tipo_De_MaterialId);
            ViewData["TBL_UsuarioId"] = new SelectList(_context.TBL_Usuarios, "Id", "CH_Nombre", tBL_Recibo_De_Reciclaje.TBL_UsuarioId);
            
            return View(tBL_Recibo_De_Reciclaje);
        }

        // GET: TBL_Recibo_De_Reciclaje/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (id == null || _context.TBL_Recibos_De_Reciclaje == null)
            {
                return NotFound();
            }

            var tBL_Recibo_De_Reciclaje = await _context.TBL_Recibos_De_Reciclaje.FindAsync(id);
            if (tBL_Recibo_De_Reciclaje == null)
            {
                return NotFound();
            }
            ViewData["CAT_Centro_De_AcopioId"] = new SelectList(_context.CAT_Centros_De_Acopio, "Id", "CH_Nombre", tBL_Recibo_De_Reciclaje.CAT_Centro_De_AcopioId);
            ViewData["CAT_Tipo_De_MaterialId"] = new SelectList(_context.CAT_Tipos_De_Materiales, "Id", "CH_Descripcion", tBL_Recibo_De_Reciclaje.CAT_Tipo_De_MaterialId);
            ViewData["TBL_UsuarioId"] = new SelectList(_context.TBL_Usuarios, "Id", "CH_Nombre", tBL_Recibo_De_Reciclaje.TBL_UsuarioId);
            
            return View(tBL_Recibo_De_Reciclaje);
        }

        // POST: TBL_Recibo_De_Reciclaje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,DTI_Fecha_Hora,DEC_Peso,CAT_Tipo_De_MaterialId,CAT_Centro_De_AcopioId,TBL_UsuarioId")] TBL_Recibo_De_Reciclaje tBL_Recibo_De_Reciclaje)
        {
            if (id != tBL_Recibo_De_Reciclaje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tBL_Recibo_De_Reciclaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TBL_Recibo_De_ReciclajeExists(tBL_Recibo_De_Reciclaje.Id))
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
            ViewData["CAT_Centro_De_AcopioId"] = new SelectList(_context.CAT_Centros_De_Acopio, "Id", "CH_Nombre", tBL_Recibo_De_Reciclaje.CAT_Centro_De_AcopioId);
            ViewData["CAT_Tipo_De_MaterialId"] = new SelectList(_context.CAT_Tipos_De_Materiales, "Id", "CH_Descripcion", tBL_Recibo_De_Reciclaje.CAT_Tipo_De_MaterialId);
            ViewData["TBL_UsuarioId"] = new SelectList(_context.TBL_Usuarios, "Id", "CH_Nombre", tBL_Recibo_De_Reciclaje.TBL_UsuarioId);
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            return View(tBL_Recibo_De_Reciclaje);
        }

        // GET: TBL_Recibo_De_Reciclaje/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (id == null || _context.TBL_Recibos_De_Reciclaje == null)
            {
                return NotFound();
            }

            var tBL_Recibo_De_Reciclaje = await _context.TBL_Recibos_De_Reciclaje
                .Include(t => t.CAT_Centros_De_Acopio)
                .Include(t => t.CAT_Tipos_De_Materiales)
                .Include(t => t.TBL_Usuarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tBL_Recibo_De_Reciclaje == null)
            {
                return NotFound();
            }
            
            return View(tBL_Recibo_De_Reciclaje);
        }

        // POST: TBL_Recibo_De_Reciclaje/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            if (_context.TBL_Recibos_De_Reciclaje == null)
            {
                return Problem("Entity set 'AppDbContext.TBL_Recibos_De_Reciclaje'  is null.");
            }
            var tBL_Recibo_De_Reciclaje = await _context.TBL_Recibos_De_Reciclaje.FindAsync(id);
            if (tBL_Recibo_De_Reciclaje != null)
            {
                _context.TBL_Recibos_De_Reciclaje.Remove(tBL_Recibo_De_Reciclaje);
            }
            
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Mantenimiento));
        }

        private bool TBL_Recibo_De_ReciclajeExists(int id)
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            return (_context.TBL_Recibos_De_Reciclaje?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
