using Fiap.Api.Trash.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Trash.Data.Repository
{
    public class EletronicoRepository : IEletronicoRepository
    {
        private readonly DatabaseContext _databaseContext;

        public EletronicoRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }


        public void Add(EletronicoModel eletronico)
        {
            _databaseContext.Eletronicos.Add(eletronico);
            _databaseContext.SaveChanges();
        }

        public void Delete(EletronicoModel eletronico)
        {
            _databaseContext.Eletronicos.Remove(eletronico);
            _databaseContext.SaveChanges();
        }

        public IEnumerable<EletronicoModel> GetAll() => _databaseContext.Eletronicos.Include(c => c.Usuario).ToList();

        public EletronicoModel GetById(int id) => _databaseContext.Eletronicos.Find(id);

        public void Update(EletronicoModel eletronico)
        {
            _databaseContext.Eletronicos.Update(eletronico);
            _databaseContext.SaveChanges();
        }
    }
}
