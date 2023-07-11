using Projeto.API.Dtos;

namespace Projeto.API.Servico.Interface;

public interface IProcessoServico
{
    Task<IEnumerable<ProcessoOutputDTO>> PegarTodos(int pagina, int tamanho, string pesquisa);
    Task<ProcessoOutputDTO> PegarPorId(int id);
    Task Criar(ProcessoInputDTO processoDTO);
    Task Atualizar(ProcessoInputDTO processoDTO);
    Task Deletar(int id);
    Task<int> TotalDados(string pesquisa);
}
