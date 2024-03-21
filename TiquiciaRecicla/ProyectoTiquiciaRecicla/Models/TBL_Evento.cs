using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTiquiciaRecicla.Models
{
    public class TBL_Evento
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        [StringLength(10, ErrorMessage = "El nombre debe tener como máximo 10 caracteres")]
        public string? CH_Nombre { get; set; }


        [Required(ErrorMessage = "La descripción es obligatoria")]
        [Display(Name = "Descripción")]
        [StringLength(150, ErrorMessage = "La descripción debe tener maximo 150 caracteres")]
        public string? CH_Descripcion { get; set; }

        [Required]
        [Display(Name = "Fecha inicio")]
        public DateTime DTI_Inicio { get; set; }

        [Required]
        [Display(Name = "Fecha finalización")]
        public DateTime DTI_Fin { get; set; }

        [Required(ErrorMessage = "El premio es obligatorio")]
        [Display(Name = "Premio")]
        [StringLength(10, ErrorMessage = "El premio debe tener como máximo 10 caracteres")]
        public string? CH_Premio { get; set; }

        //Relacion con tabla empresa_recolectora
        [Required(ErrorMessage = "La empresa recolectora es obligatoria")]
        [ForeignKey("CAT_Empresa_Recolectora")]
        [Display(Name = "Id de empresas recolectoras")]
        public int CAT_Empresa_RecolectoraId { get; set; }

        [Display(Name = "Empresas recolectora")]
        public virtual CAT_Empresa_Recolectora? CAT_Empresas_Recolectoras { get; set; }
    }
}
