using Fiap.Api.Trash.Models;

namespace Fiap.Api.Trash.Services
{
    public interface INotificacaoService
    {
        IEnumerable<NotificacaoModel> ListarNotificacoes(); //consulta tudo
        NotificacaoModel ObterNotificacoesPorId(int id); //pega os detalhes 
        void CriarNotificacao(NotificacaoModel notificacao); //adiciona
        void AtualizarNotificacao(NotificacaoModel notificacao); //atualiza
        void DeletarNotificacao(int id); //Apaga
    }
}
