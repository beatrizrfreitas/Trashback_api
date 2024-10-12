using Fiap.Api.Trash.Data.Repository;
using Fiap.Api.Trash.Models;

namespace Fiap.Api.Trash.Services
{
    public class DescarteService : IDescarteService
    {
        private readonly IDescarteRepository _repository;

        public DescarteService(IDescarteRepository repository)
        {            
            _repository = repository;
        }

        public IEnumerable<DescarteModel> ListarDescarte() => _repository.GetAll();
        public DescarteModel ObterDescartePorId(int id) => _repository.GetById(id);
        public void CriarDescarte(DescarteModel descarte) => _repository.Add(descarte);
        public void AtualizarDescarte(DescarteModel descarte) => _repository.Update(descarte);

        public void DeletarDescarte(int id)
        {
            var descarte = _repository.GetById(id);
            if (descarte != null)
            {
                _repository.Delete(descarte);
            }
        }
    }
}
