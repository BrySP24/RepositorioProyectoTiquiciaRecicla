using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTiquiciaRecicla.Data;
using ProyectoTiquiciaRecicla.Models;

namespace ProyectoTiquiciaRecicla.ViewComponents
{
    [ViewComponent(Name = "DatosUsosProvincias")]
    public class DatosUsosProvinciasComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public DatosUsosProvinciasComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var resultado = from hs in _context.TBL_Historicos_Sesiones
                        join u in _context.TBL_Usuarios on hs.TBL_UsuarioId equals u.Id into userGroup
                        from user in userGroup.DefaultIfEmpty()
                        join p in _context.CAT_Provincias on user.CAT_ProvinciaId equals p.Id into provinceGroup
                        from province in provinceGroup.DefaultIfEmpty()
                        group hs by province.CH_Nombre into grouped
                        select new BI_UsosProvincias
                        {
                            ID = 0,
                            Nombre = grouped.Key,
                            Sesiones = grouped.Count(x => x.DIT_Fecha_Hora_Cierre != null)
                        };

            return View(await resultado.ToListAsync());
        }
    }
}
