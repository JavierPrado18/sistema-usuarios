using System.ComponentModel.DataAnnotations;

namespace SistemaUsuarios.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        [MaxLength(150)]
        public required string Usuario { get; set; } 

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public required string Password { get; set; }
    }
}