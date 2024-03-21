using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTiquiciaRecicla.Models
{
    public class TBL_Historico_Sesion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Fecha de inicio de sesión")]
        public DateTime DTI_Fecha_Hora_Inicio { get; set; }

        [Required]
        [Display(Name = "Fecha de cierre de sesión")]
        public DateTime DIT_Fecha_Hora_Cierre { get; set; }

        //Relaciones claves foraneas 
        [Required]
        [ForeignKey("TBL_Usuario")]
        [Display(Name = "Id de usuario")]
        public int TBL_UsuarioId { get; set; }

        [Display(Name = "Usuario")]
        public virtual TBL_Usuario? TBL_Usuarios { get; set; }
    }
}
