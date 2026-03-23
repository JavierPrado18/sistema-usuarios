using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaUsuarios.Models.Entities
{
    public enum TipoDocumento
    {
        DNI = 1,
        CarnetExtranjeria = 2,
    }

    public enum Sexo
    {
        Masculino = 1,
        Femenino = 2,
        Otro = 3
    }

    public enum TipoTelefono
    {
        Celular = 1,
        Fijo = 2
    }

    public class Persona
    {
        public int Id { get; init; }

        [Required, MaxLength(100)]
        public string Nombres { get; init; }

        [Required, MaxLength(100)]
        public string PrimerApellido { get; init; }

        [MaxLength(100)]
        public string SegundoApellido { get; init; }

        [Required]
        public TipoDocumento TipoDocumentoIdentidad { get; init; }

        [Required, MaxLength(20)]
        public string NumeroDocumentoIdentidad { get; init; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; init; }

        [MaxLength(50)]
        public string Nacionalidad { get; init; }

        public Sexo Sexo { get; init; } 

        [MaxLength(20)]
        public string TelefonoMovil { get; init; }

        [MaxLength(20)]
        public string TelefonoSecundario { get; init; }
        
        public TipoTelefono? TipoTelefonoSecundario { get; init; }
    }
}