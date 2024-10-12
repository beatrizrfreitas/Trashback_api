namespace Fiap.Api.Trash.Models
{
    public class DescarteModel
    {
        public int DescarteId { get; set; }
        public DateTime Data { get; set; }
        public string? Endereco { get; set; }
        public string? Descricao { get; set; }
    }
}
