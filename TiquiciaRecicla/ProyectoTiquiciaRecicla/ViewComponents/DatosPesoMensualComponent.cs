using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTiquiciaRecicla.Data;
using ProyectoTiquiciaRecicla.Models;

namespace ProyectoTiquiciaRecicla.ViewComponents
{
    [ViewComponent(Name = "DatosPesoMensual")]
    public class DatosPesoMensualComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public DatosPesoMensualComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var sixMonthsAgo = DateTime.Now.AddMonths(-6).AddDays(1 - DateTime.Now.Day);

            var resultado = from r in _context.TBL_Recibos_De_Reciclaje
                        where r.DTI_Fecha_Hora >= sixMonthsAgo
                        group r by r.DTI_Fecha_Hora.Month into grouped
                        select new BI_PesoMensual
                        {
                            Id = 0,
                            Mes = grouped.Key,
                            Peso_Total = grouped.Sum(x => x.DEC_Peso)
                        };

            return View(await resultado.ToListAsync());
        }
    }
}
