using Projeto.WEP.Models;

namespace Projeto.WEP.Services.Interface;

public interface ISessaoService
{
    Task CriarSessaoUsuario(UsuarioToken usuarioToken);
    Task RemoverSessaoUsuario();
    Task<UsuarioToken> BuscarSessaoUsuario();
}
