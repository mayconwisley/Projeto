using Projeto.API.Models;

namespace Projeto.API.Repositorio.Interface;

public interface IControleCaixaRepositorio
{
    Task<IEnumerable<ControleCaixa>> PegarTodos(int pagina, int tamanho, string pesquisa);
    Task<ControleCaixa> PegarPorId(int id);
    Task<ControleCaixa> Criar(ControleCaixa tipoArquivo);
    Task<ControleCaixa> Atualizar(ControleCaixa tipoArquivo);
    Task<ControleCaixa> Deletar(int id);
    Task<int> TotalDados(string pesquisa);
}
