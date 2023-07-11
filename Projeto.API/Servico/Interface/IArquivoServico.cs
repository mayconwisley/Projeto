using Projeto.API.Dtos;

namespace Projeto.API.Servico.Interface;

public interface IArquivoServico
{
    Task<IEnumerable<ArquivoOutputDTO>> PegarTodos(int pagina, int tamanho, string pesquisa);
    Task<IEnumerable<ArquivoOutputDTO>> PegarTodosAtivos(int pagina, int tamanho, string pesquisa);
    Task<ArquivoOutputDTO> PegarPorId(int id);
    Task Criar(ArquivoInputDTO arquivoDTO);
    Task Atualizar(ArquivoInputDTO arquivoDTO);
    Task Deletar(int id);
    Task<int> TotalDados(string pesquisa);
}
