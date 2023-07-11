using Projeto.API.Models;

namespace Projeto.API.Repositorio.Interface;

public interface IUsuarioRepositorio
{
    Task<IEnumerable<Usuario>> PegarTodos(int pagina, int tamanho, string pesquisa);
    Task<IEnumerable<Usuario>> PegarTodosAtivos(int pagina, int tamanho, string pesquisa);
    Task<Usuario> PegarPorId(int id);
    Task<Usuario> PegarPorLogin(string login);
    Task<Usuario> Criar(Usuario usuario);
    Task<Usuario> Atualizar(Usuario usuario);
    Task<Usuario> Deletar(int id);
    Task<Usuario> Acessar(Acesso acesso);
    Task<int> TotalDados(string pesquisa);
}
