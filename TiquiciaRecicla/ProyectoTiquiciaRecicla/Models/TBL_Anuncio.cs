using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTiquiciaRecicla.Models
{
    public class TBL_Anuncio
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [Display(Name = "Título")]
        [StringLength(50, ErrorMessage = "El título debe tener como máximo 50 caracteres")]
        public string? CH_Titulo { get; set; }

        [Required, Display(Name = "Imagen de anuncio")]
        [StringLength(1024, MinimumLength = 5, ErrorMessage = "La imagen debe tener entre 5 y 1024 caracteres")]
        public string? IMG_Banner { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [Display(Name = "Descripción")]
        [StringLength(150, ErrorMessage = "La descripción debe tener maximo 150 caracteres")]
        public string? CH_Descripcion{ get; set; }

        //Relacion con centros de acopio
        [Required]
        [ForeignKey("CAT_Centro_De_Acopio")]
        [Display(Name = "Id de centros de acopio")]
        public int CAT_Centro_De_AcopioId { get; set; }

        [Display(Name = "Centros de acopio")]
        public virtual CAT_Centro_De_Acopio? CAT_Centros_De_Acopio { get; set; }
    }
}
