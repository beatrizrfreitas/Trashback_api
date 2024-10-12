using Fiap.Api.Trash.Models;

namespace Fiap.Api.Trash.Data.Repository
{
    public interface IEletronicoRepository
    {
        IEnumerable<EletronicoModel> GetAll(); //consulta tudo
        EletronicoModel GetById(int id); //pega os detalhes 
        void Add(EletronicoModel eletronico); //adiciona
        void Update(EletronicoModel eletronico); //atualiza
        void Delete(EletronicoModel eletronico); //Apaga
    }
}
