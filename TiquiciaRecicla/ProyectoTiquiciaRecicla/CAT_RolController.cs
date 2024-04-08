using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoTiquiciaRecicla.Data;
using ProyectoTiquiciaRecicla.Models;

namespace ProyectoTiquiciaRecicla
{
    public class CAT_RolController : Controller
    {
        private readonly AppDbContext _context;

        public CAT_RolController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CAT_Rol
        public async Task<IActionResult> Index()
        {
              return _context.CAT_Roles != null ? 
                          View(await _context.CAT_Roles.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.CAT_Roles'  is null.");
        }

        // GET: CAT_Rol/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CAT_Roles == null)
            {
                return NotFound();
            }

            var cAT_Rol = await _context.CAT_Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cAT_Rol == null)
            {
                return NotFound();
            }

            return View(cAT_Rol);
        }

        // GET: CAT_Rol/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CAT_Rol/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CH_Nombre")] CAT_Rol cAT_Rol)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cAT_Rol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cAT_Rol);
        }

        // GET: CAT_Rol/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CAT_Roles == null)
            {
                return NotFound();
            }

            var cAT_Rol = await _context.CAT_Roles.FindAsync(id);
            if (cAT_Rol == null)
            {
                return NotFound();
            }
            return View(cAT_Rol);
        }

        // POST: CAT_Rol/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CH_Nombre")] CAT_Rol cAT_Rol)
        {
            if (id != cAT_Rol.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cAT_Rol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CAT_RolExists(cAT_Rol.Id))
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
            return View(cAT_Rol);
        }

        // GET: CAT_Rol/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CAT_Roles == null)
            {
                return NotFound();
            }

            var cAT_Rol = await _context.CAT_Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cAT_Rol == null)
            {
                return NotFound();
            }

            return View(cAT_Rol);
        }

        // POST: CAT_Rol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CAT_Roles == null)
            {
                return Problem("Entity set 'AppDbContext.CAT_Roles'  is null.");
            }
            var cAT_Rol = await _context.CAT_Roles.FindAsync(id);
            if (cAT_Rol != null)
            {
                _context.CAT_Roles.Remove(cAT_Rol);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CAT_RolExists(int id)
        {
          return (_context.CAT_Roles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
