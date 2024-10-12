using Fiap.Api.Trash.Models;

namespace Fiap.Api.Trash.Data.Repository
{
    public class DescarteRepository : IDescarteRepository
    {
        private readonly DatabaseContext _databaseContext;
        public DescarteRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }
        public void Add(DescarteModel descarte)
        {
            _databaseContext.Descartes.Add(descarte);
            _databaseContext.SaveChanges();
        }

        public void Delete(DescarteModel descarte)
        {
            _databaseContext.Descartes.Remove(descarte);
            _databaseContext.SaveChanges();
        }

        public IEnumerable<DescarteModel> GetAll() => _databaseContext.Descartes.ToList();

        public DescarteModel GetById(int id) => _databaseContext.Descartes.Find(id);

        public void Update(DescarteModel descarte)
        {
            _databaseContext.Descartes.Update(descarte);
            _databaseContext.SaveChanges();
        }
    }
}
