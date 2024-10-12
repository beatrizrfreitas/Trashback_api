using Fiap.Api.Trash.Models;

namespace Fiap.Api.Trash.ViewModels
{
    public class UsuarioPaginacaoReferenciaViewModel
    {
        public IEnumerable<UsuarioModel> Usuario { get; set; }
        public int PageSize { get; set; }
        public int Ref { get; set; }
        public int NextRef { get; set; }
        public string PreviousPageUrl => $"/Usuario?referencia={Ref}&tamanho={PageSize}";
        public string NextPageUrl => (Ref < NextRef) ? $"/Usuario?referencia={NextRef}&tamanho={PageSize}" : "";

    }
}
