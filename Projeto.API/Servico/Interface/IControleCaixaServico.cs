using Projeto.API.Dtos;

namespace Projeto.API.Servico.Interface;

public interface IControleCaixaServico
{
    Task<IEnumerable<ControleCaixaOutputDTO>> PegarTodos(int pagina, int tamanho, string pesquisa);
    Task<ControleCaixaOutputDTO> PegarPorId(int id);
    Task Criar(ControleCaixaInputDTO controleCaixaDTO);
    Task Atualizar(ControleCaixaInputDTO controleCaixaDTO);
    Task Deletar(int id);
    Task<int> TotalDados(string pesquisa);
}
