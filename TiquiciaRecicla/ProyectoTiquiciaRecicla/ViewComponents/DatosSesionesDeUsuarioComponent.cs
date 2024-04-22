using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTiquiciaRecicla.Data;
using ProyectoTiquiciaRecicla.Models;

namespace ProyectoTiquiciaRecicla.ViewComponents
{
    [ViewComponent(Name = "DatosSesionesDeUsuario")]
    public class DatosSesionesDeUsuarioComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public DatosSesionesDeUsuarioComponent(AppDbContext context)
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
                        select new BI_SesionesDeUsuario
                        {
                            Id = user.Id,
                            Correo = user.CH_Correo,
                            Nombre = user.CH_Nombre,
                            Apellido_1 = user.CH_Apellido_1,
                            Apellido_2 = user.CH_apellido_2,
                            Provincia = province.CH_Nombre,
                            Fecha_Hora_Inicio = hs.DTI_Fecha_Hora_Inicio,
                            Fecha_Hora_Cierre = hs.DIT_Fecha_Hora_Cierre
                        };

            return View(await resultado.ToListAsync());
        }
    }
}
