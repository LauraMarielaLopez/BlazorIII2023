using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Usuario
    {
        [Required(ErrorMessage = "El código es obligatorio")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = "La clave es obligatoria")]
        public string Clave { get; set; }
        public string? Correo { get; set; }
        [Required(ErrorMessage = "El rol es obligatorio")]
        public string Rol { get; set; }
        public bool EstaActivo { get; set; }
    }
}