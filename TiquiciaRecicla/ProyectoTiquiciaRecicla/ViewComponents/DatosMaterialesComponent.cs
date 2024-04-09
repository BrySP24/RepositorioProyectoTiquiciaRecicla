using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTiquiciaRecicla.Data;
using ProyectoTiquiciaRecicla.Models;

namespace ProyectoTiquiciaRecicla.ViewComponents

{
    [ViewComponent(Name = "DatosMateriales")]
    public class DatosMaterialesComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public DatosMaterialesComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var resultado = from r in _context.TBL_Recibos_De_Reciclaje
                        join m in _context.CAT_Tipos_De_Materiales on r.CAT_Tipo_De_MaterialId equals m.Id into materialGroup
                        from material in materialGroup.DefaultIfEmpty()
                        group r by material.CH_Nombre into grouped
                        select new BI_Materiales
                        {
                            Id = 0,
                            Nombre = grouped.Key,
                            Peso_Total = grouped.Sum(x => x.DEC_Peso)
                        };

            return View(await resultado.ToListAsync());
        }

    }
}
