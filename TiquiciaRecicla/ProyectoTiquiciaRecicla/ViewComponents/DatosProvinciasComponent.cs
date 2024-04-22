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
            var resultado = from rr in _context.TBL_Recibos_De_Reciclaje
                        join u in _context.TBL_Usuarios on rr.TBL_UsuarioId equals u.Id into userGroup
                        from user in userGroup.DefaultIfEmpty()
                        join p in _context.CAT_Provincias on user.CAT_ProvinciaId equals p.Id into provinceGroup
                        from province in provinceGroup.DefaultIfEmpty()
                        group rr by province.CH_Nombre into grouped
                        select new BI_Provincias
                        {
                            ID = 0,
                            Nombre = grouped.Key,
                            Peso_Total = grouped.Sum(x => x.DEC_Peso)
                        };

            return View(await resultado.ToListAsync());
        }
    }
}
