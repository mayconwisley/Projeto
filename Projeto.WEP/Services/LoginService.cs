using Projeto.WEP.Models;
using Projeto.WEP.Services.Interface;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace Projeto.WEP.Services;

public class LoginService : ILoginService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private const string? apiEndPoint = "api/Login/";
    private readonly JsonSerializerOptions _serializerOptions;
    private readonly UsuarioToken? usuarioToken;

    public LoginService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<UsuarioToken> Acessar(LoginViewModel loginVM)
    {
        var client = _httpClientFactory.CreateClient("DadosConexaoApi");
        StringContent stringContent = new(JsonSerializer.Serialize(loginVM), Encoding.UTF8, "application/json");

        using (var res = await client.PostAsync(apiEndPoint, stringContent))
        {
            if (res.IsSuccessStatusCode)
            {
                await using var resApi = await res.Content.ReadAsStreamAsync();
                var tokenUsuario = await JsonSerializer.DeserializeAsync<UsuarioToken>(resApi, _serializerOptions);
                if (tokenUsuario is not null)
                {
                    return tokenUsuario;
                }
            }

        }
        return usuarioToken;
    }
}
