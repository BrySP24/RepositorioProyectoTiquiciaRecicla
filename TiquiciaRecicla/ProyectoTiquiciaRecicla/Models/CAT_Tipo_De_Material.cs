using System.ComponentModel.DataAnnotations;

namespace ProyectoTiquiciaRecicla.Models
{
    public class CAT_Tipo_De_Material
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre del material")]
        [StringLength(50, ErrorMessage = "El nombre debe tener como máximo 50 caracteres")]
        public string? CH_Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [Display(Name = "Descripción")]
        [StringLength(150, ErrorMessage = "El nombre debe tener como máximo 150 caracteres")]
        public string? CH_Descripcion { get; set; }


        [Required(ErrorMessage = "El tratamiento es obligatorio")]
        [Display(Name = "Tratamiento")]
        [StringLength(150, ErrorMessage = "El nombre debe tener como máximo 150 caracteres")]
        public string? CH_Tratamiento { get; set; }
    }
}
