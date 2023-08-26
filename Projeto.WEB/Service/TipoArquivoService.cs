using Projeto.WEB.Model;
using Projeto.WEB.Service.Interface;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace Projeto.WEB.Service;

public class TipoArquivoService : ITipoArquivoService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly JsonSerializerOptions _serializerOptions;
    private const string? apiEndPoint = "api/TipoArquivo";
    private readonly TipoArquivoDto tipoArquivoDto = new();
    private readonly TipoArquivoView tipoArquivoView = new();

    public TipoArquivoService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<TipoArquivoView> PegarTodos(int pagina = 1, int tamanho = 25, string pesquisa = "")
    {
        try
        {
            var httpClient = _httpClientFactory.CreateClient("ConexaoApi");

            var tipoArquivoView = await httpClient.GetFromJsonAsync<TipoArquivoView>(apiEndPoint + $"?pagina={pagina}&tamanho={tamanho}&pesquisa={pesquisa}");

            if (tipoArquivoView is not null)
            {
                return tipoArquivoView;
            }
            return new TipoArquivoView();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public Task<TipoArquivoView> PegarTodosAtivos(int pagina = 1, int tamanho = 25, string pesquisa = "")
    {
        throw new NotImplementedException();
    }

    public Task<TipoArquivoDto> PegarPorId(int id)
    {
        throw new NotImplementedException();
    }

    public Task<TipoArquivoDto> Cadastrar(TipoArquivoDto tipoArquivo)
    {
        throw new NotImplementedException();
    }

    public Task<TipoArquivoDto> Atualizar(TipoArquivoDto tipoArquivo)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Deletar(int id)
    {
        throw new NotImplementedException();
    }
}
