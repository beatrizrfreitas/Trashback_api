using Fiap.Api.Trash.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Trash.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UsuarioRepository(DatabaseContext context)
        {
            _databaseContext = context;
            
        }

        public IEnumerable<UsuarioModel> GetAll() => _databaseContext.Usuarios.ToList();

        public IEnumerable<UsuarioModel> GetAll(int page, int size)
        {
            //throw new NotImplementedException();
            return _databaseContext.Usuarios
                        .Skip((page - 1) * page)
                        .Take(size)
                        .AsNoTracking()
                        .ToList();
        }

        public IEnumerable<UsuarioModel> GetAllReference(int lastReference, int size)
        {
            // throw new NotImplementedException();
            var usuario = _databaseContext.Usuarios
                             .Where(c => c.UserId > lastReference)
                             .OrderBy(c => c.UserId)
                             .Take(size)
                             .AsNoTracking()
                             .ToList();

            return usuario;
        }

        public UsuarioModel GetById(int id) => _databaseContext.Usuarios.Find(id);

        public void Add(UsuarioModel usuario)
        {
            _databaseContext.Usuarios.Add(usuario);
            _databaseContext.SaveChanges();
        }

        public void Delete(UsuarioModel usuario)
        {
            _databaseContext.Usuarios.Remove(usuario);
            _databaseContext.SaveChanges();
        }
        public void Update(UsuarioModel usuario)
        {
            _databaseContext.Usuarios.Update(usuario);
            _databaseContext.SaveChanges();
        }
    }
}
