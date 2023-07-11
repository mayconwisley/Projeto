using Projeto.API.Models;

namespace Projeto.API.Repositorio.Interface;

public interface ITipoArquivoRepositorio
{
    Task<IEnumerable<TipoArquivo>> PegarTodos(int pagina, int tamanho, string pesquisa);
    Task<IEnumerable<TipoArquivo>> PegarTodosAtivos(int pagina, int tamanho, string pesquisa);
    Task<TipoArquivo> PegarPorId(int id);
    Task<TipoArquivo> Criar(TipoArquivo tipoArquivo);
    Task<TipoArquivo> Atualizar(TipoArquivo tipoArquivo);
    Task<TipoArquivo> Deletar(int id);
    Task<int> TotalDados(string pesquisa);
}
