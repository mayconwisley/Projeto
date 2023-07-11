using Projeto.API.Models;

namespace Projeto.API.Repositorio.Interface;

public interface IArquivoRepositorio
{
    Task<IEnumerable<Arquivo>> PegarTodos(int pagina, int tamanho, string pesquisa);
    Task<IEnumerable<Arquivo>> PegarTodosAtivos(int pagina, int tamanho, string pesquisa);
    Task<Arquivo> PegarPorId(int id);
    Task<Arquivo> Criar(Arquivo arquivo);
    Task<Arquivo> Atualizar(Arquivo arquivo);
    Task<Arquivo> Deletar(int id);
    Task<int> TotalDados(string pesquisa);
}
