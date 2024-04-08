using Microsoft.EntityFrameworkCore;
using ProyectoTiquiciaRecicla.Models;

namespace ProyectoTiquiciaRecicla.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<CAT_Provincia> CAT_Provincias { get; set; }

        public DbSet<TBL_Usuario> TBL_Usuarios { get; set; }

        public DbSet<TBL_Historico_Sesion> TBL_Historicos_Sesiones { get; set; }

        public DbSet<TBL_Recibo_De_Reciclaje> TBL_Recibos_De_Reciclaje { get; set; }

        public DbSet<CAT_Tipo_De_Material> CAT_Tipos_De_Materiales { get; set; }

        public DbSet<CAT_Empresa_Recolectora> CAT_Empresas_Recolectoras { get; set; }

        public DbSet<CAT_Centro_De_Acopio> CAT_Centros_De_Acopio { get; set; }

        public DbSet<TBL_Zona_de_Recolecta> TBL_Zonas_de_Recolecta { get; set; }

        public DbSet<TBL_Anuncio> TBL_Anuncios { get; set; }

        public DbSet<TBL_Evento> TBL_Eventos { get; set; }

        public DbSet<CAT_Centro_Material> CAT_Centros_Materiales { get; set; }

        public DbSet<CAT_Rol> CAT_Roles { get; set; }
    }

}