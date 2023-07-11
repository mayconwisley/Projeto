using Projeto.API.Dtos;

namespace Projeto.API.Servico.Interface;

public interface IControleCaixaServico
{
    Task<IEnumerable<ControleCaixaDTO>> PegarTodos(int pagina, int tamanho, string pesquisa);
    Task<ControleCaixaDTO> PegarPorId(int id);
    Task Criar(ControleCaixaDTO controleCaixa);
    Task Atualizar(ControleCaixaDTO controleCaixa);
    Task Deletar(int id);
    Task<int> TotalDados(string pesquisa);
}
