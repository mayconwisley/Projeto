using Projeto.API.Dtos;

namespace Projeto.API.Servico.Interface;

public interface IUsuarioServico
{
    Task<IEnumerable<UsuarioOutputDTO>> PegarTodos(int pagina, int tamanho, string pesquisa);
    Task<IEnumerable<UsuarioOutputDTO>> PegarTodosAtivos(int pagina, int tamanho, string pesquisa);
    Task<UsuarioOutputDTO> PegarPorId(int id);
    Task<UsuarioOutputDTO> PegarPorLogin(string login);
    Task Criar(UsuarioInputDTO usuarioDTO);
    Task Atualizar(UsuarioInputDTO usuarioDTO);
    Task Deletar(int id);
    Task<UsuarioOutputDTO> Acessar(AcessoDTO acessoDTO);
    Task<int> TotalDados(string pesquisa);
}
