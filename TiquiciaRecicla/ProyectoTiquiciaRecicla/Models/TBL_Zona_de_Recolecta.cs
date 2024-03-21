using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTiquiciaRecicla.Models
{
    public class TBL_Zona_de_Recolecta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [Display(Name = "Dirección")]
        [StringLength(50, ErrorMessage = "La dirección debe tener maximo 50 caracteres")]
        public string? CH_Direccion { get; set; }

        [Required(ErrorMessage = "La latidud es obligatoria")]
        [Display(Name = "Latitud")]
        public double DEC_Latitud { get; set; }

        [Required(ErrorMessage = "La longitud es obligatoria")]
        [Display(Name = "Longitud")]
        public double DEC_Longitud { get; set; }

        [Required]
        [Display(Name = "Fecha inicio")]
        public DateTime DTI_Inicio { get; set; }

        [Required]
        [Display(Name = "Fecha finalización")]
        public DateTime DTI_Fin { get; set; }

        [Required(ErrorMessage = "El horario es obligatorio")]
        [Display(Name = "Horario")]
        [StringLength(50, ErrorMessage = "El horario debe tener maximo 50 caracteres")]
        public string? CH_Horario { get; set; }

        //Relacion con centros de acopio
        [Required]
        [ForeignKey("CAT_Centro_De_Acopio")]
        [Display(Name = "Id de centros de acopio")]
        public int CAT_Centro_De_AcopioId { get; set; }

        [Display(Name = "Centros de acopio")]
        public virtual CAT_Centro_De_Acopio? CAT_Centros_De_Acopio { get; set; }

    }
}
