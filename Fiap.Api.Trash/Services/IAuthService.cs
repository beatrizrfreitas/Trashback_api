using Fiap.Api.Trash.Models;

namespace Fiap.Api.Trash.Services
{
    public interface IAuthService
    {
        FuncionarioModel Authenticate(string username, string password);
    }
}
