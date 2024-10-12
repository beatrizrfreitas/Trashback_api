namespace Fiap.Api.Trash.Models
{
    public class NotificacaoModel
    {
        public int NotificacaoId { get; set; }
        public string? Titulo { get; set; }
        public string? Mensagem { get; set; }
        public DateTime Data { get; set; }

        //relacionamento com usuario
        public int UserId { get; set; }
        public UsuarioModel Usuario { get; set; }
    }
}
