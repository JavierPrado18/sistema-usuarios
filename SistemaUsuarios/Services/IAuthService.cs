using System.Threading.Tasks;

namespace SistemaUsuarios.Services
{
    public enum LoginResult
    {
        Success,
        InvalidCredentials,
        AccountLocked
    }

    public interface IAuthService
    {
        Task<LoginResult> ValidarLoginAsync(string correo, string password);
    }
}