using Projeto.WEB.Model;

namespace Projeto.WEB.Service.Interface
{
    public interface IControleCaixaService
    {
        Task<ControleCaixaOutputView> PegarTodos(int pagina = 1, int tamanho = 25, string pesquisa = "");
        Task<ControleCaixaOutputView> PegarTodosAtivos(int pagina = 1, int tamanho = 25, string pesquisa = "");
        Task<ControleCaixaOutputDto> PegarPorId(int id);
        Task<ControleCaixaInputDto> Cadastrar(ControleCaixaInputDto controleCaixaInput);
        Task<ControleCaixaInputDto> Atualizar(ControleCaixaInputDto controleCaixaInput);
        Task<bool> Deletar(int id);
    }
}
