using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTiquiciaRecicla.Models
{
    public class TBL_Recibo_De_Reciclaje
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Fecha y hora")]
        public DateTime DTI_Fecha_Hora { get; set; }

        [Required]
        [Display(Name = "Peso en Km")]
        public float DEC_Peso { get; set; }
        
        //Relacion con Tipo_De_Materiales
        [Required]
        [ForeignKey("CAT_Tipo_De_Material")]
        [Display(Name = "Id de materiales")]
        public int CAT_Tipo_De_MaterialId { get; set; }

        [Display(Name = "Materiales")]
        public virtual CAT_Tipo_De_Material? CAT_Tipos_De_Materiales { get; set; }

        //Relacion con Centros_de_acopio
        [Required]
        [ForeignKey("CAT_Centro_De_Acopio")]
        [Display(Name = "Centros de acopio")]
        public int CAT_Centro_De_AcopioId { get; set; }

        [Display(Name = "Centros de acopio")]
        public virtual CAT_Centro_De_Acopio? CAT_Centros_De_Acopio { get; set; }

        //Relacion con Usuario
        [Required]
        [ForeignKey("TBL_Usuario")]
        [Display(Name = "Usuarios")]
        public int TBL_UsuarioId { get; set; }

        [Display(Name = "Usuarios")]
        public virtual TBL_Usuario? TBL_Usuarios { get; set; }
    }
}
