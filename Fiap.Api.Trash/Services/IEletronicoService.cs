using Fiap.Api.Trash.Models;

namespace Fiap.Api.Trash.Services
{
    public interface IEletronicoService
    {
        IEnumerable<EletronicoModel> ListarEletronico(); //consulta tudo
        EletronicoModel ObterEletronicoPorId(int id); //pega os detalhes 
        void CriarEletronico(EletronicoModel eletronico); //adiciona
        void AtualizarEletronicos(EletronicoModel eletronico); //atualiza
        void DeletarEletronicos(int id); //Apaga
    }
}
