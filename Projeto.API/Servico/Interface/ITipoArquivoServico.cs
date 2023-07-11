using Projeto.API.Dtos;

namespace Projeto.API.Servico.Interface;

public interface ITipoArquivoServico
{
    Task<IEnumerable<TipoArquivoDTO>> PegarTodos(int pagina, int tamanho, string pesquisa);
    Task<IEnumerable<TipoArquivoDTO>> PegarTodosAtivos(int pagina, int tamanho, string pesquisa);
    Task<TipoArquivoDTO> PegarPorId(int id);
    Task Criar(TipoArquivoDTO tipoArquivoDTO);
    Task Atualizar(TipoArquivoDTO tipoArquivoDTO);
    Task Deletar(int id);
    Task<int> TotalDados(string pesquisa);
}
