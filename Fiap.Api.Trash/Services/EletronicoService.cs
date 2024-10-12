using Fiap.Api.Trash.Data.Repository;
using Fiap.Api.Trash.Models;

namespace Fiap.Api.Trash.Services
{
    public class EletronicoService : IEletronicoService
    {
        private readonly IEletronicoRepository _repository;

        public EletronicoService(IEletronicoRepository repository)
        {
            
            _repository = repository;
        }

        public IEnumerable<EletronicoModel> ListarEletronico() => _repository.GetAll();
        public EletronicoModel ObterEletronicoPorId(int id) => _repository.GetById(id);
        public void CriarEletronico(EletronicoModel eletronico) => _repository.Add(eletronico);
        public void AtualizarEletronicos(EletronicoModel eletronico) => _repository.Update(eletronico);

        public void DeletarEletronicos(int id)
        {
            var eletronico = _repository.GetById(id);
            if (eletronico != null)
            {
                _repository.Delete(eletronico);
            }
        }
    }
}
