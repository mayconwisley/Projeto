using Projeto.API.Dtos;

namespace Projeto.API.Servico.Interface;

public interface IArquivoServico
{
    Task<IEnumerable<ArquivoDTO>> PegarTodos(int pagina, int tamanho, string pesquisa);
    Task<IEnumerable<ArquivoDTO>> PegarTodosAtivos(int pagina, int tamanho, string pesquisa);
    Task<ArquivoDTO> PegarPorId(int id);
    Task Criar(ArquivoDTO arquivo);
    Task Atualizar(ArquivoDTO arquivo);
    Task Deletar(int id);
    Task<int> TotalDados(string pesquisa);
}
