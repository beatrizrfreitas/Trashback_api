using Fiap.Api.Trash.Models;

namespace Fiap.Api.Trash.Services
{
    public interface IUsuarioService
    {
        IEnumerable<UsuarioModel> ListarUsuarios(); //consulta todos os usuarios
        IEnumerable<UsuarioModel> ListarUsuarios(int pagina = 0, int tamanho = 10); //pagina e tamanho
        IEnumerable<UsuarioModel> ListarUsuariosUltimaReferencia(int ultimoId = 0, int tamanho = 10); //ultima referencia
        UsuarioModel ObterUsuarioPorId(int id); //pega os detalhes do usuario
        void CriarUsuario(UsuarioModel usuario); //adiciona
        void AtualizarUsuario(UsuarioModel usuario); //atualiza
        void DeletarUsuario(int id); //Apaga

     }
}
