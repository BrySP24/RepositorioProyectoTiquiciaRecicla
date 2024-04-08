using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTiquiciaRecicla.Models
{
    public class TBL_Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener 2 y 50 caracteres")]
        public string? CH_Nombre{ get; set; }

        [Required(ErrorMessage = "El primer apellido es un campo obligatorio")]
        [Display(Name = "Primer Apellido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El apellido debe tener 2 y 50 caracteres")]
        public string? CH_Apellido_1 { get; set; }

        [Required(ErrorMessage = "El segundo apellido es un campo obligatorio")]
        [Display(Name = "Segundo Apellido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El segundo apellido debe tener 2 y 50 caracteres")]
        public string? CH_apellido_2 { get; set; }

        [Required(ErrorMessage = "El correo electrónico es un campo obligatorio")]
        [StringLength(50, ErrorMessage = "El correo electrónico debe tener como máximo 50 caracteres")]
        [Display(Name = "Correo electrónico")]
        [EmailAddress(ErrorMessage = "Por favor ingrese una dirección de correo electrónico válida")]
        public string? CH_Correo { get; set; }

        [Required(ErrorMessage = "La contraseña es un campo obligatorio")]
        [Display(Name = "Contraseña")]
        [StringLength(100, ErrorMessage = "La contraseña debe tener como máximo 100 caracteres")]
        [DataType(DataType.Password)]
        public string? CH_Clave { get; set; }

       /* [Required]
        [Compare("CH_Clave", ErrorMessage = "Las contraseñas no coinciden")]
        [StringLength(100, ErrorMessage = "La contraseña debe tener como máximo 100 caracteres")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        public string? CH_Clave_2 { get; set; }*/

        [Required]
        [Display(Name = "Teléfono")]
        [StringLength(8, ErrorMessage = "La dirección debe tener como máximo 8 caracteres")]
        [RegularExpression(@"^(?:\d{8}|\d{2}-\d{2}-\d{2}-\d{2})$", ErrorMessage = "El número de teléfono debe tener 8 dígitos.")]
        public string? CH_Telefono { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        [StringLength(100, ErrorMessage = "La dirección debe tener como máximo 100 caracteres")]
        public string? CH_Direccion { get; set; }


        //Relaciones claves foraneas 
        [Required(ErrorMessage = "La selección de una provincia es obligatoria")]
        [ForeignKey("CAT_Provincia")]
        [Display(Name = "Provincias")]
        public int CAT_ProvinciaId { get; set; }

        [Display(Name = "Provincia")]
        public virtual CAT_Provincia? CAT_Provincias { get; set; }

        

        //Relacion con tabla rol
      
        [ForeignKey("CAT_Rol")]
        [Display(Name = "Roles")]
        public int CAT_RolId { get; set; }

        [Display(Name = "Rol")]
        public virtual CAT_Rol? CAT_Roles { get; set; }


        //Para que genere una lista de usuarios existentes en recibos de reciclaje
        //public List<TBL_Recibos_De_Reciclaje>? TBL_Recibos_De_Reciclajes { get; set; }
    }
}
