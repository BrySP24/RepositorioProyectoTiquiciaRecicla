namespace ProyectoTiquiciaRecicla.Models
{
    public class BI_SesionesDeUsuario
    {
        public int Id { get; set; }
        public string Correo {  get; set; }
        public string Nombre { get; set; }
        public string Apellido_1 { get; set; }
        public string Apellido_2 { get; set; }
        public string Provincia { get; set; }
        public DateTime Fecha_Hora_Inicio { get; set; }
        public DateTime Fecha_Hora_Cierre { get; set; }

    }
}
