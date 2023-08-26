using Projeto.WEB.Model;
using Projeto.WEB.Service.Interface;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace Projeto.WEB.Service;

public class UsuarioService : IUsuarioService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly JsonSerializerOptions _serializerOptions;
    private const string? apiEndPoint = "api/Usuario";
    private readonly UsuarioInputDto usuarioInputDto = new();
    private readonly UsuarioOutputDto usuarioOutputDto = new();
    private readonly UsuarioOutputView usuarioOutputView = new();

    public UsuarioService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<UsuarioOutputView> PegarTodos(int pagina = 1, int tamanho = 25, string pesquisa = "")
    {
        try
        {
            var httpClient = _httpClientFactory.CreateClient("ConexaoApi");

            var usuarioOutputView = await httpClient.GetFromJsonAsync<UsuarioOutputView>(apiEndPoint + $"?pagina={pagina}&tamanho={tamanho}&pesquisa={pesquisa}");

            if (usuarioOutputView is not null)
            {
                return usuarioOutputView;
            }
            return new UsuarioOutputView();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<UsuarioOutputView> PegarTodosAtivos(int pagina = 1, int tamanho = 25, string pesquisa = "")
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioOutputDto> PegarPorId(int id)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioInputDto> Cadastrar(UsuarioInputDto usuario)
    {
        throw new NotImplementedException();
    }

    public Task<UsuarioInputDto> Atualizar(UsuarioInputDto usuario)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Deletar(int id)
    {
        throw new NotImplementedException();
    }
}