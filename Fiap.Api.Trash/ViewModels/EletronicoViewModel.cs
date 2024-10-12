using Fiap.Api.Trash.Models;

namespace Fiap.Api.Trash.ViewModels
{
    public class EletronicoViewModel
    {
        public int EletronicoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public int UserId { get; set; }
        public UsuarioModel Usuario { get; set; }
    }
}
