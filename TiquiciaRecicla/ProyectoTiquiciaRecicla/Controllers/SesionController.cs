using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProyectoTiquiciaRecicla.Data;
using ProyectoTiquiciaRecicla.Models;
using ProyectoTiquiciaRecicla.Utilidades;

namespace ProyectoTiquiciaRecicla.Controllers
{
    public class SesionController : Controller
    {
        private readonly AppDbContext _context;

        public SesionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Registro/Create
        public IActionResult Registro()
        {
            ViewData["CAT_ProvinciaId"] = new SelectList(_context.CAT_Provincias, "Id", "CH_Nombre");
            return View();
        }

        // POST: Registro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro([Bind("Id,CH_Nombre,CH_Apellido_1,CH_apellido_2,CH_Correo,CH_Clave,CH_Telefono,CH_Direccion,CAT_ProvinciaId")] TBL_Usuario tBL_Usuario)
        {
            if (ModelState.IsValid)
            {
                tBL_Usuario.CAT_RolId = 2;

                // Hash de la contraseña antes de guardarla
                tBL_Usuario.CH_Clave = PasswordHasher.HashPassword(tBL_Usuario.CH_Clave);

                _context.Add(tBL_Usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Inicio_Sesion));
            }
            ViewData["CAT_ProvinciaId"] = new SelectList(_context.CAT_Provincias, "Id", "CH_Nombre", tBL_Usuario.CAT_ProvinciaId);
            return View(tBL_Usuario);
        }

        // GET: Sesion/Login
        public IActionResult Inicio_Sesion()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inicio_Sesion(TBL_Usuario usuario)
        {
            // Busca el usuario en la base de datos basado en el correo electrónico
            var usuarioEncontrado = _context.TBL_Usuarios.SingleOrDefault(u => u.CH_Correo == usuario.CH_Correo);

            if (usuarioEncontrado != null)
            {
                var hashedPassword = PasswordHasher.HashPassword(usuario.CH_Clave);

                if (usuarioEncontrado.CH_Clave == hashedPassword)
                {
                    // Autenticación exitosa
                    HomeController.VariablesGlobales.UsuarioId = usuarioEncontrado.Id;
                    HomeController.VariablesGlobales.UsuarioSesion = 1;
                    HomeController.VariablesGlobales.UsuarioRol = usuarioEncontrado.CAT_RolId;
                    ViewBag.UsuarioSesion = 1; // Establecer UsuarioSesion en ViewBag
                    return RedirectToAction("Index", "Home"); // Redirigir al usuario a la página de inicio después de iniciar sesión.
                }
            }

            // Si el usuario no existe o la contraseña no coincide, muestra un mensaje de error
            ModelState.AddModelError(string.Empty, "Correo electrónico o contraseña incorrectos");
            return View();
        }

        public async Task<IActionResult> Cerrar_Sesion()
        {
            // Cerrar la sesión del usuario
            HomeController.VariablesGlobales.UsuarioSesion = 0;
            HomeController.VariablesGlobales.UsuarioId = 0;
            HomeController.VariablesGlobales.UsuarioRol = 0;
            ViewBag.UsuarioSesion = 0; // Establecer UsuarioSesion en ViewBag

            // Redirigir al usuario a la página de inicio o a donde desees después de cerrar sesión
            return RedirectToAction("Index", "Home");
        }
    }

}
