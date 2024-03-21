using System.ComponentModel.DataAnnotations;

namespace ProyectoTiquiciaRecicla.Models
{
    public class CAT_Empresa_Recolectora
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre de la empresa recolectora")]
        [StringLength(50, ErrorMessage = "El nombre de la empresa recolectora debe tener maximo 50 caracteres")]
        public string? CH_Nombre { get; set; }

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

        [Required(ErrorMessage = "El horario es obligatorio")]
        [Display(Name = "Horario")]
        [StringLength(50, ErrorMessage = "El horario debe tener maximo 50 caracteres")]
        public string? CH_Horario { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        [StringLength(8, ErrorMessage = "El número de teléfono debe tener como máximo 8 caracteres")]
        [RegularExpression(@"^(?:\d{8}|\d{2}-\d{2}-\d{2}-\d{2})$", ErrorMessage = "El número de teléfono debe tener 8 dígitos.")]
        public string? CH_Telefono { get; set; }

        [Required(ErrorMessage = "El correo electrónico es un campo obligatorio")]
        [StringLength(50, ErrorMessage = "El correo electrónico debe tener como máximo 50 caracteres")]
        [Display(Name = "Correo electrónico")]
        [EmailAddress(ErrorMessage = "Por favor ingrese una dirección de correo electrónico válida")]
        public string? CH_Correo_Electronico { get; set; }

        //Para que genere una lista Empresasa existentes en el crud de centros de acopio.
        public ICollection<CAT_Centro_De_Acopio>? CAT_Centros_De_Acopios { get; set; }
             
    }
}
