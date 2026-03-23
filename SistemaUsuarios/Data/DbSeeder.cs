using SistemaUsuarios.Models.Entities;

namespace SistemaUsuarios.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Usuarios.Any()) return;

            var institucion = new Institucion { Codigo = "INST01", Nombre = "Institución Principal", Activo = true };
            var rolAdmin = new Rol { Nombre = "Administrador", Descripcion = "Acceso total", Activo = true };
            
            var persona = new Persona 
            {
                Nombres = "Javier", 
                PrimerApellido = "Prado", 
                SegundoApellido = "Gomez",
                TipoDocumentoIdentidad = TipoDocumento.DNI,
                NumeroDocumentoIdentidad = "12345678",
                FechaNacimiento = new DateTime(2003, 1, 1), 
                Nacionalidad = "Peruana",
                Sexo = Sexo.Masculino, 
                TelefonoMovil = "999888777", 
                TelefonoSecundario = ""
            };

            context.Instituciones.Add(institucion);
            context.Roles.Add(rolAdmin);
            context.Personas.Add(persona);
            context.SaveChanges(); 

            var usuarios = new List<Usuario>
            {
                new Usuario
                {
                    PersonaId = persona.Id,
                    RolId = rolAdmin.Id,
                    InstitucionId = institucion.Id,
                    CorreoElectronicoPrincipal = "prueba@gmail.com",
                    CorreoElectronicoSecundario = "",
                    TipoContratacion = "Planilla",
                    EstadoValidacionPIDE = "Validado",
                    PasswordHash = "123456", 
                    Activo = true,
                    IntentosFallidos = 0
                },
                new Usuario
                {
                    PersonaId = persona.Id,
                    RolId = rolAdmin.Id,
                    InstitucionId = institucion.Id,
                    CorreoElectronicoPrincipal = "bloqueo@gmail.com",
                    CorreoElectronicoSecundario = "",
                    TipoContratacion = "Recibos",
                    EstadoValidacionPIDE = "Validado",
                    PasswordHash = "123456",
                    Activo = true,
                    IntentosFallidos = 0
                }
            };

            context.Usuarios.AddRange(usuarios);
            context.SaveChanges();
        }
    }
}