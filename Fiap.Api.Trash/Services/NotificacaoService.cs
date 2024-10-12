using Fiap.Api.Trash.Data.Repository;
using Fiap.Api.Trash.Models;

namespace Fiap.Api.Trash.Services
{
    public class NotificacaoService : INotificacaoService
    {
        private readonly INotificacaoRepository _repository;

        public NotificacaoService(INotificacaoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<NotificacaoModel> ListarNotificacoes() => _repository.GetAll();
        public NotificacaoModel ObterNotificacoesPorId(int id) => _repository.GetById(id);
        public void CriarNotificacao(NotificacaoModel notificacao) => _repository.Add(notificacao);
        public void AtualizarNotificacao(NotificacaoModel notificacao) => _repository.Update(notificacao);

        public void DeletarNotificacao(int id)
        {
            var notificacao = _repository.GetById(id);
            if (notificacao != null)
            {
                _repository.Delete(notificacao);
            }
        }



    }
}
