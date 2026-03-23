using Microsoft.EntityFrameworkCore;
using SistemaUsuarios.Data;
using SistemaUsuarios.Models;

namespace SistemaUsuarios.Services.Impl
{
    public class AuthService(AppDbContext context) : IAuthService
    {
        public async Task<LoginResult> ValidarLoginAsync(string usuario, string password)
        {
            var user = await context.Usuarios
                .SingleOrDefaultAsync(u => u.CorreoElectronicoPrincipal == usuario && u.Activo);

            if (user == null) return LoginResult.InvalidCredentials;

            if (user.BloqueadoHasta.HasValue && user.BloqueadoHasta > DateTime.UtcNow)
            {
                return LoginResult.AccountLocked;
            }

            if (user.PasswordHash != password) 
            {
                user.IntentosFallidos++;
                
                if (user.IntentosFallidos >= 5)
                {
                    user.BloqueadoHasta = DateTime.UtcNow.AddMinutes(15);
                }

                await context.SaveChangesAsync();
                
                return user.IntentosFallidos >= 5 
                    ? LoginResult.AccountLocked 
                    : LoginResult.InvalidCredentials;
            }

            user.IntentosFallidos = 0;
            user.BloqueadoHasta = null;
            user.UltimoAcceso = DateTime.UtcNow;
            
            await context.SaveChangesAsync();
            return LoginResult.Success;
        }
    }
}