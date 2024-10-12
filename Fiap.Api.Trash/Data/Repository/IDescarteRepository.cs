using Fiap.Api.Trash.Models;

namespace Fiap.Api.Trash.Data.Repository
{
    public interface IDescarteRepository
    {
        IEnumerable<DescarteModel> GetAll(); //consulta tudo
        DescarteModel GetById(int id); //pega os detalhes 
        void Add(DescarteModel descarte); //adiciona
        void Update(DescarteModel descarte); //atualiza
        void Delete(DescarteModel descarte); //Apaga
    }
}
