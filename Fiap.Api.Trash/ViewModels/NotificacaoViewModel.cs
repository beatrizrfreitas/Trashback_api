using Fiap.Api.Trash.Models;

namespace Fiap.Api.Trash.ViewModels
{
    public class NotificacaoViewModel
    {
        public int NotificacaoId { get; set; }
        public string? Titulo { get; set; }
        public string? Mensagem { get; set; }
        public DateTime Data { get; set; }
        public int UserId { get; set; }
        public UsuarioModel Usuario { get; set; }
    }
}
