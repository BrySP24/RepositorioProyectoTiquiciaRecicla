using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTiquiciaRecicla.Data;
using ProyectoTiquiciaRecicla.Models;

namespace ProyectoTiquiciaRecicla.ViewComponents
{
    [ViewComponent(Name = "DatosCentrosDeAcopio")]
    public class DatosCentrosDeAcopioComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public DatosCentrosDeAcopioComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var resultado1 = from r in _context.TBL_Recibos_De_Reciclaje
                        join m in _context.CAT_Tipos_De_Materiales on r.CAT_Tipo_De_MaterialId equals m.Id into materialGroup
                        from material in materialGroup.DefaultIfEmpty()
                        join a in _context.CAT_Centros_De_Acopio on r.CAT_Centro_De_AcopioId equals a.Id into centroGroup
                        from centro in centroGroup.DefaultIfEmpty()
                        group r by new { CentroNombre = centro.CH_Nombre, MaterialNombre = material.CH_Nombre } into grouped
                        select new BI_CentrosDeAcopio
                        {
                            Id = 0,
                            Nombre_1 = grouped.Key.MaterialNombre,
                            Nombre_2 = grouped.Key.CentroNombre,
                            Peso_Total = grouped.Sum(x => x.DEC_Peso)
                        };

            var resultado2 = from r in _context.TBL_Recibos_De_Reciclaje
                        join a in _context.CAT_Centros_De_Acopio on r.CAT_Centro_De_AcopioId equals a.Id into centroGroup
                        from centro in centroGroup.DefaultIfEmpty()
                        group r by centro.CH_Nombre into grouped
                        select new BI_CentrosDeAcopio
                        {
                            Id = 0,
                            Nombre_1 = grouped.Key,
                            Nombre_2 = "Global",
                            Peso_Total = grouped.Sum(x => x.DEC_Peso)
                        };

            var resultado1_enlistado = await resultado1.ToListAsync();
            var resultado2_enlistado = await resultado2.ToListAsync();

            return View(resultado1_enlistado.Concat(resultado2_enlistado));
        }
    }
}
