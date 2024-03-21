using System.ComponentModel.DataAnnotations;

namespace ProyectoTiquiciaRecicla.Models
{
    public class CAT_Provincia
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre de provincia")]
        [StringLength(10, ErrorMessage = "El nombre debe tener como máximo 10 caracteres")]
        public string? CH_Nombre { get; set; }

        //Para que genere una lista provincias existentes en el crud de Usuarios
        public ICollection<TBL_Usuario>? TBL_Usuarios { get; set; }
    }
}
