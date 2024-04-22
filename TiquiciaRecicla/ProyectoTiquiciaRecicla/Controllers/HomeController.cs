using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoTiquiciaRecicla.Models;

namespace ProyectoTiquiciaRecicla.Controllers
{
    public class HomeController : Controller
    {
        public static class VariablesGlobales
        {
            public static int UsuarioId { get; set; } = 0;
            public static int UsuarioSesion { get; set; } = 0;
            public static int UsuarioRol { get; set; }
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            int usuarioId = VariablesGlobales.UsuarioId;
            ViewData["usuarioId"] = usuarioId;
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            int usuarioSesion = VariablesGlobales.UsuarioSesion;
            ViewData["usuarioSesion"] = usuarioSesion;
            return View();
        }

        public IActionResult Privacidad()
        {
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
