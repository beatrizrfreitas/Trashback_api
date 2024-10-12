using Fiap.Api.Trash.Models;

namespace Fiap.Api.Trash.Data.Repository
{
    public interface INotificacaoRepository
    {
        IEnumerable<NotificacaoModel> GetAll(); //consulta tudo
        NotificacaoModel GetById(int id); //pega os detalhes 
        void Add(NotificacaoModel notificacao); //adiciona
        void Update(NotificacaoModel notificacao); //atualiza
        void Delete(NotificacaoModel notificacao); //Apaga
    }
}
