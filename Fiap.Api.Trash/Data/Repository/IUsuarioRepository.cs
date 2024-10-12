using Fiap.Api.Trash.Models;

namespace Fiap.Api.Trash.Data.Repository
{
    public interface IUsuarioRepository
    {
        
        IEnumerable<UsuarioModel> GetAll(); //consulta todos os usuarios
        UsuarioModel GetById(int id); //pega os detalhes do usuario
        void Add(UsuarioModel usuario); //adiciona
        void Update(UsuarioModel usuario); //atualiza
        void Delete(UsuarioModel usuario); //Apaga

        IEnumerable<UsuarioModel> GetAll(int page, int size); //pagina e tamanho
        IEnumerable<UsuarioModel> GetAllReference(int lastReference, int size); //ultima referencia
    }
}
