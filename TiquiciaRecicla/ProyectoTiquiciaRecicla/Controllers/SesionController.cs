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
    public class SesionController : Controller
    {
        private readonly AppDbContext _context;

        public SesionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Sesion
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.TBL_Usuarios.Include(t => t.CAT_Provincias);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Sesion/Create
        public IActionResult Registro()
        {
            ViewData["CAT_ProvinciaId"] = new SelectList(_context.CAT_Provincias, "Id", "CH_Nombre");
            return View();
        }

        // POST: Sesion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro([Bind("Id,CH_Nombre,CH_Apellido_1,CH_apellido_2,CH_Correo,CH_Clave,CH_Telefono,CH_Direccion,CAT_ProvinciaId")] TBL_Usuario tBL_Usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tBL_Usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CAT_ProvinciaId"] = new SelectList(_context.CAT_Provincias, "Id", "CH_Nombre", tBL_Usuario.CAT_ProvinciaId);
            return View(tBL_Usuario);
        }

        // GET: Sesion/Create
        public IActionResult Inicio_Sesion()
        {
            ViewData["CAT_ProvinciaId"] = new SelectList(_context.CAT_Provincias, "Id", "CH_Nombre");
            return View();
        }

        // POST: Sesion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inicio_Sesion([Bind("Id,CH_Nombre,CH_Apellido_1,CH_apellido_2,CH_Correo,CH_Clave,CH_Telefono,CH_Direccion,CAT_ProvinciaId")] TBL_Usuario tBL_Usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tBL_Usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CAT_ProvinciaId"] = new SelectList(_context.CAT_Provincias, "Id", "CH_Nombre", tBL_Usuario.CAT_ProvinciaId);
            return View(tBL_Usuario);
        }

        private bool TBL_UsuarioExists(int id)
        {
          return (_context.TBL_Usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
