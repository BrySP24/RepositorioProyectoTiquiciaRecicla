using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTiquiciaRecicla.Data;
using ProyectoTiquiciaRecicla.Models;

namespace ProyectoTiquiciaRecicla.ViewComponents
{
    [ViewComponent(Name = "DatosKPIsUsosMensuales")]
    public class DatosKPIsUsosMensualesComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public DatosKPIsUsosMensualesComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var resultado1 = from hs in _context.TBL_Historicos_Sesiones
                                    where hs.DTI_Fecha_Hora_Inicio.Month == _context.TBL_Historicos_Sesiones.Max(x => x.DTI_Fecha_Hora_Inicio.Month) &&
                                          hs.DTI_Fecha_Hora_Inicio.Year == _context.TBL_Historicos_Sesiones.Max(x => x.DTI_Fecha_Hora_Inicio.Year)
                                    select new
                                    {
                                        AverageDuration = EF.Functions.DateDiffMinute(hs.DTI_Fecha_Hora_Inicio, hs.DIT_Fecha_Hora_Cierre),
                                        Count = 1
                                    } into temp
                                    group temp by 1 into grouped
                                    select new BI_KPIs
                                    {
                                        ID = 0,
                                        Valor_1 = (float)grouped.Average(x => x.AverageDuration),
                                        Valor_2 = grouped.Sum(x => x.Count)
                                    };

            var resultado2 = from hs in _context.TBL_Historicos_Sesiones
                                     where hs.DTI_Fecha_Hora_Inicio.Month == _context.TBL_Historicos_Sesiones.Max(x => x.DTI_Fecha_Hora_Inicio.Month) - 1 &&
                                           hs.DTI_Fecha_Hora_Inicio.Year == _context.TBL_Historicos_Sesiones.Max(x => x.DTI_Fecha_Hora_Inicio.Year)
                                     select new
                                     {
                                         AverageDuration = EF.Functions.DateDiffMinute(hs.DTI_Fecha_Hora_Inicio, hs.DIT_Fecha_Hora_Cierre),
                                         Count = 1
                                     } into temp
                                     group temp by 1 into grouped
                                     select new BI_KPIs
                                     {
                                         ID = 0,
                                         Valor_1 = (float)grouped.Average(x => x.AverageDuration),
                                         Valor_2 = grouped.Sum(x => x.Count)
                                     };


            var resultado1_enlistado = await resultado1.ToListAsync();
            var resultado2_enlistado = await resultado2.ToListAsync();

            return View(resultado1_enlistado.Concat(resultado2_enlistado));

        }
    }
}
