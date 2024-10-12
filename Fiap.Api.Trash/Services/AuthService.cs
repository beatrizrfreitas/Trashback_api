using Fiap.Api.Trash.Services;
using Fiap.Api.Trash.Models;

namespace Fiap.Api.Trash.Services
{
    public class AuthService : IAuthService
    {
        private List<FuncionarioModel> _funcionarios = new List<FuncionarioModel>
        {
                    new FuncionarioModel { FunId = 1, Username = "operador01", Password = "pass123", Role = "operador" },
                    new FuncionarioModel { FunId = 2, Username = "analista01", Password = "pass123", Role = "analista" },
                    new FuncionarioModel { FunId = 3, Username = "gerente01", Password = "pass123", Role = "gerente" },
                    new FuncionarioModel { FunId = 4, Username = "operador02", Password = "pass123", Role = "operador" },
                    new FuncionarioModel { FunId = 5, Username = "analista02", Password = "pass123", Role = "analista" },
                    new FuncionarioModel { FunId = 6, Username = "gerente02", Password = "pass123", Role = "gerente" },
                    new FuncionarioModel { FunId = 7, Username = "operador03", Password = "pass123", Role = "operador" }
        };

        public FuncionarioModel Authenticate(string username, string password)
        {
            // Aqui você normalmente faria a verificação de senha de forma segura
            return _funcionarios.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
