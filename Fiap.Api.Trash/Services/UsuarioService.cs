using Fiap.Api.Trash.Data.Repository;
using Fiap.Api.Trash.Models;

namespace Fiap.Api.Trash.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UsuarioModel> ListarUsuarios() => _repository.GetAll();

        public IEnumerable<UsuarioModel> ListarUsuarios(int pagina = 1, int tamanho = 10)
        {
            return _repository.GetAll(pagina, tamanho);
        }

        public IEnumerable<UsuarioModel> ListarUsuariosUltimaReferencia(int ultimoId = 0, int tamanho = 10)
        {
            return _repository.GetAllReference(ultimoId, tamanho);
        }
        public UsuarioModel ObterUsuarioPorId(int id) => _repository.GetById(id);
        public void CriarUsuario(UsuarioModel usuario) => _repository.Add(usuario);
        public void AtualizarUsuario(UsuarioModel usuario) => _repository.Update(usuario);
        public void DeletarUsuario(int id)
        {
            var usuario = _repository.GetById(id);
            if (usuario != null)
            {
                _repository.Delete(usuario);
            }
        }

    }
}
