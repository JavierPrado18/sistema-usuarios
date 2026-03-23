using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaUsuarios.Models.Entities
{
    public class Usuario
    {
        public int Id { get; init; }

        public int PersonaId { get; init ; }
        public Persona Persona { get; init; }

        [Required, EmailAddress, MaxLength(150)]
        public string CorreoElectronicoPrincipal { get; init; }

        [EmailAddress, MaxLength(150)]
        public string CorreoElectronicoSecundario { get; init; }

        [MaxLength(50)]
        public string TipoContratacion { get; init; } 

        [DataType(DataType.Date)]
        public DateTime? FechaContratacion { get; init; }

        [MaxLength(50)]
        public string EstadoValidacionPIDE { get; init; }

        [Required]
        public string PasswordHash { get; init; }

        public bool Activo { get; init; } = true;

        public int IntentosFallidos { get; set; } = 0; 
        public DateTime? BloqueadoHasta { get; set; } 
        public DateTime? UltimoAcceso { get; set; }

        public int RolId { get; set; }
        public Rol Rol { get; set; }

        public int InstitucionId { get; set; }
        public Institucion Institucion { get; set; }
    }
}
