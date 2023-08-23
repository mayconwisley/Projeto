using Projeto.WEB.Model;

namespace Projeto.WEB.Service.Interface;

public interface IUsuarioServices
{
    Task<UsuarioOutputView> PegarTodos(int pagina = 1, int tamanho = 25, string pesquisa = "");
    Task<UsuarioOutputView> PegarTodosAtivos(int pagina = 1, int tamanho = 25, string pesquisa = "");
    Task<UsuarioOutputDto> PegarPorId(int id);
    Task<UsuarioInputDto> Cadastrar(UsuarioInputDto usuario);
    Task<UsuarioInputDto> Atualizar(UsuarioInputDto usuario);
    Task<bool> Deletar(int id);
}
