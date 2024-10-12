using Fiap.Api.Trash.Models;

namespace Fiap.Api.Trash.Services
{
    public interface IDescarteService
    {
        IEnumerable<DescarteModel> ListarDescarte(); //consulta tudo
        DescarteModel ObterDescartePorId(int id); //pega os detalhes 
        void CriarDescarte(DescarteModel descarte); //adiciona
        void AtualizarDescarte(DescarteModel descarte); //atualiza
        void DeletarDescarte(int id); //Apaga
    }
}
