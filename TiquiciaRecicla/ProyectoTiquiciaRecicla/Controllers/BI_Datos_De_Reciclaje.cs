using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using ProyectoTiquiciaRecicla.Data;
using ProyectoTiquiciaRecicla.Models;

namespace ProyectoTiquiciaRecicla.Controllers
{
    public class BI_Datos_De_Reciclaje : Controller
    {
        private readonly AppDbContext _context;

        public BI_Datos_De_Reciclaje(AppDbContext context)
        {
            _context = context;
        }

        // GET: BI_Datos_De_Reciclaje
        public async Task<IActionResult> Dashboard()
        {
            var appDbContext = _context.TBL_Recibos_De_Reciclaje.Include(t => t.CAT_Centros_De_Acopio).Include(t => t.CAT_Tipos_De_Materiales).Include(t => t.TBL_Usuarios);
            return View(await appDbContext.ToListAsync());
        }


        private bool TBL_Recibo_De_ReciclajeExists(int id)
        {
          return (_context.TBL_Recibos_De_Reciclaje?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
