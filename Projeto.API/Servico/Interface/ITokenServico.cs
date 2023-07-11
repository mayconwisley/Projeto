using Projeto.API.Dtos;

namespace Projeto.API.Servico.Interface;

public interface ITokenServico
{
    Task<string> GerarToken(UsuarioOutputDTO usuarioDTO);
}
