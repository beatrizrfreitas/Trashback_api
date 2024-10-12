using Fiap.Api.Trash.Models;

namespace Fiap.Api.Trash.ViewModels
{
    public class UsuarioPaginacaoViewModel
    {
        public IEnumerable<UsuarioModel> Usuario { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => Usuario.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/Usuario?pagina={CurrentPage - 1}&tamanho={PageSize}" : "";
        public string NextPageUrl => HasNextPage ? $"/Usuario?pagina={CurrentPage + 1}&tamanho={PageSize}" : "";

    }
}
