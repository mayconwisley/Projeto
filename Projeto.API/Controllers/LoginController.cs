using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.API.Dtos;
using Projeto.API.Servico.Interface;

namespace Projeto.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUsuarioServico _usuarioServico;
    private readonly ITokenServico _tokenServico;

    public LoginController(IUsuarioServico usuarioServico, ITokenServico tokenServico)
    {
        _usuarioServico = usuarioServico;
        _tokenServico = tokenServico;
    }

    [HttpPost]
    public async Task<ActionResult<UsuarioOutputDTO>> Post([FromBody] AcessoDTO acesso)
    {
        if (acesso is not null)
        {
            var usuario = await _usuarioServico.Acessar(acesso);

            if (usuario.Login == "")
            {
                return NotFound("Usuário ou Senha Inválidos");
            }

            string token = await _tokenServico.GerarToken(usuario);

            return Ok(new
            {
                usuario,
                token
            });
        }
        return BadRequest("Dados Incorretos");
    }
}
