using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTiquiciaRecicla.Models
{
    public class CAT_Centro_Material
    {

        [Key]
        public int Id { get; set; }

        //Relacion con tipos de materiales
        [Required]
        [ForeignKey("CAT_Tipo_De_Material")]
        [Display(Name = "Id de tipos de materiales")]
        public int CAT_Tipo_De_MaterialId { get; set; }

        [Display(Name = "Tipos de materiales")]
        public virtual CAT_Tipo_De_Material? CAT_Tipos_De_Materiales { get; set; }

        //Relacion con Centros de acopio
        [Required]
        [ForeignKey("CAT_Centro_De_Acopio")]
        [Display(Name = "Id de centros de acopio")]
        public int CAT_Centro_De_AcopioId { get; set; }

        [Display(Name = "Centros de acopio")]
        public virtual CAT_Centro_De_Acopio? CAT_Centros_De_Acopio { get; set; }
    }
}
