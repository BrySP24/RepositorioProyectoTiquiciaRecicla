using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTiquiciaRecicla.Data;
using ProyectoTiquiciaRecicla.Models;

namespace ProyectoTiquiciaRecicla.ViewComponents
{
    [ViewComponent(Name = "DatosProvincias")]
    public class DatosProvinciasComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public DatosProvinciasComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var resultado = _context.TBL_Recibos_De_Reciclaje
            .SelectMany(r => _context.CAT_Tipos_De_Materiales.Where(m => r.CAT_Tipo_De_MaterialId == m.Id).DefaultIfEmpty(), (r, m) => new { r, m })
            .GroupBy(m => new { m.r.CAT_Tipo_De_MaterialId, m.m.CH_Nombre }, m => m.r)
            .Select(d => new BI_Materiales { Id = d.Key.CAT_Tipo_De_MaterialId, Nombre = d.Key.CH_Nombre, Peso_Total = d.Sum(x => x.DEC_Peso) });

            return View(await resultado.ToListAsync());
        }
    }
}
