using Projeto.WEB.Model;

namespace Projeto.WEB.Service.Interface;

public interface ITipoArquivoServices
{
    Task<TipoArquivoView> PegarTodos(int pagina = 1, int tamanho = 25, string pesquisa = "");
    Task<TipoArquivoView> PegarTodosAtivos(int pagina = 1, int tamanho = 25, string pesquisa = "");
    Task<TipoArquivoDto> PegarPorId(int id);
    Task<TipoArquivoDto> Cadastrar(TipoArquivoDto tipoArquivo);
    Task<TipoArquivoDto> Atualizar(TipoArquivoDto tipoArquivo);
    Task<bool> Deletar(int id);
}
