using Projeto.API.Models;

namespace Projeto.API.Repositorio.Interface;

public interface IItemArquivoRepositorio
{
    Task<IEnumerable<ItemArquivo>> PegarTodos(int pagina, int tamanho, string pesquisa);
    Task<ItemArquivo> PegarPorId(int id);
    Task<ItemArquivo> Criar(ItemArquivo itemArquivo);
    Task<ItemArquivo> Atualizar(ItemArquivo itemArquivo);
    Task<ItemArquivo> Deletar(int id);
    Task<int> TotalDados(string pesquisa);
}
