using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProyectoTiquiciaRecicla.Models;

namespace ProyectoTiquiciaRecicla.Models
{
    public class CAT_Rol
    {


        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener 2 y 50 caracteres")]
        public string? CH_Nombre { get; set; }

        public ICollection<CAT_Rol>? CAT_Roles { get; set; }

    }
}