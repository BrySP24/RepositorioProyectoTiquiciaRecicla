using Microsoft.AspNetCore.Mvc;
using static ProyectoTiquiciaRecicla.Controllers.HomeController;

namespace ProyectoTiquiciaRecicla.Controllers
{
    public class BI_Datos_De_Uso_Aplicacion : Controller
    {
        public IActionResult Dashboard()
        {
            int usuarioRol = VariablesGlobales.UsuarioRol;
            ViewData["usuarioRol"] = usuarioRol;
            ViewBag.UsuarioSesion = VariablesGlobales.UsuarioSesion;
            return View();
        }
    }
}
