using Projeto.WEB.Model;

namespace Projeto.WEB.Service.Interface
{
    public interface IArquivoService
    {
        Task<ArquivoOutputView> PegarTodos(int pagina = 1, int tamanho = 25, string pesquisa = "");
        Task<ArquivoOutputView> PegarTodosAtivos(int pagina = 1, int tamanho = 25, string pesquisa = "");
        Task<ArquivoOutputDto> PegarPorId(int id);
        Task<ArquivoInputDto> Cadastrar(ArquivoInputDto arquivoInputDto);
        Task<ArquivoInputDto> Atualizar(ArquivoInputDto arquivoInputDto);
        Task<bool> Deletar(int id);
    }
}
