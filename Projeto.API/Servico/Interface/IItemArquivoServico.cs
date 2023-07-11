using Projeto.API.Dtos;

namespace Projeto.API.Servico.Interface;

public interface IItemArquivoServico
{
    Task<IEnumerable<ItemArquivoOutputDTO>> PegarTodos(int pagina, int tamanho, string pesquisa);
    Task<ItemArquivoOutputDTO> PegarPorId(int id);
    Task Criar(ItemArquivoInputDTO itemArquivoDTO);
    Task Atualizar(ItemArquivoInputDTO itemArquivoDTO);
    Task Deletar(int id);
    Task<int> TotalDados(string pesquisa);
}
