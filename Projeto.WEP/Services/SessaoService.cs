using Projeto.WEP.Models;
using Projeto.WEP.Services.Interface;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Projeto.WEP.Services;

public class SessaoService : ISessaoService
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly JsonSerializerOptions _serializerOptions;

    public SessaoService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
        _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<UsuarioToken> BuscarSessaoUsuario()
    {
        string? sessaoUsuario = await Task.FromResult(_contextAccessor.HttpContext.Session.GetString("usuarioLogado"));

        if (string.IsNullOrEmpty(sessaoUsuario))
        {
            return null;
        }

        UsuarioToken? usuarioToken = JsonSerializer.Deserialize<UsuarioToken>(sessaoUsuario);

        return usuarioToken;
    }

    public async Task CriarSessaoUsuario(UsuarioToken usuarioToken)
    {
        string sessaoUsuario = JsonSerializer.Serialize(usuarioToken);
        _contextAccessor.HttpContext.Session.SetString("usuarioLogado", sessaoUsuario);
    }

    public async Task RemoverSessaoUsuario()
    {
        _contextAccessor.HttpContext.Session.Remove("usuarioLogado");
    }
}
