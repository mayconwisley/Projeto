using Projeto.WEP.Models;

namespace Projeto.WEP.Services.Interface;

public interface ILoginService
{
    Task<UsuarioToken> Acessar(LoginViewModel loginViewModel);
}
