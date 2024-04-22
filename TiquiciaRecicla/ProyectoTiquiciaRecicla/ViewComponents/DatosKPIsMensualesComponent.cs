using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTiquiciaRecicla.Data;
using ProyectoTiquiciaRecicla.Models;

namespace ProyectoTiquiciaRecicla.ViewComponents
{
    [ViewComponent(Name = "DatosKPIsMensuales")]
    public class DatosKPIsMensualesComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public DatosKPIsMensualesComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var resultado1 = (from r in _context.TBL_Recibos_De_Reciclaje
                                     where r.DTI_Fecha_Hora.Month == _context.TBL_Recibos_De_Reciclaje.Max(x => x.DTI_Fecha_Hora).Month &&
                                           r.DTI_Fecha_Hora.Year == _context.TBL_Recibos_De_Reciclaje.Max(x => x.DTI_Fecha_Hora).Year
                                     select new BI_KPIs
                                     {
                                         ID = 0,
                                         Valor_1 = r.DEC_Peso,
                                         Valor_2 = 1
                                     }).GroupBy(x => 1)
                         .Select(g => new BI_KPIs
                         {
                             ID = 0,
                             Valor_1 = g.Sum(x => x.Valor_1),
                             Valor_2 = g.Count()
                         });

            var resultado2 = (from r in _context.TBL_Recibos_De_Reciclaje
                                      where r.DTI_Fecha_Hora.Month == _context.TBL_Recibos_De_Reciclaje.Max(x => x.DTI_Fecha_Hora).Month - 1 &&
                                            r.DTI_Fecha_Hora.Year == _context.TBL_Recibos_De_Reciclaje.Max(x => x.DTI_Fecha_Hora).Year
                                      select new BI_KPIs
                                      {
                                          ID = 0,
                                          Valor_1 = r.DEC_Peso,
                                          Valor_2 = 1
                                      }).GroupBy(x => 1)
                                      .Select(g => new BI_KPIs
                                      {
                                          ID = 0,
                                          Valor_1 = g.Sum(x => x.Valor_1),
                                          Valor_2 = g.Count()
                                      });

            var resultado1_enlistado = await resultado1.ToListAsync();
            var resultado2_enlistado = await resultado2.ToListAsync();

            return View(resultado1_enlistado.Concat(resultado2_enlistado));

        }
    }
}
