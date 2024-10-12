namespace Fiap.Api.Trash.Models
{
    public class EletronicoModel
    {
        public int EletronicoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }

        //relacionamento com usuario
        public int UserId { get; set; }
        public UsuarioModel Usuario { get; set; }
    }
}
