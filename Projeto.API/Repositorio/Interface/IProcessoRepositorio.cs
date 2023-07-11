using Projeto.API.Models;

namespace Projeto.API.Repositorio.Interface;

public interface IProcessoRepositorio
{
    Task<IEnumerable<Processo>> PegarTodos(int pagina, int tamanho, string pesquisa);
    Task<Processo> PegarPorId(int id);
    Task<Processo> Criar(Processo processo);
    Task<Processo> Atualizar(Processo processo);
    Task<Processo> Deletar(int id);
    Task<int> TotalDados(string pesquisa);
}
