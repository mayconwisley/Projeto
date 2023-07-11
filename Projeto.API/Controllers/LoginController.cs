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
    public async Task<ActionResult<UsuarioOutputDTO>> Post([FromBody] LoginDTO acessoDTO)
    {
        if (acessoDTO is not null)
        {
            var usuarioDTO = await _usuarioServico.Acessar(acessoDTO);

            if (usuarioDTO.Login == "")
            {
                return NotFound("Login ou Senha Inválidos");
            }

            string token = await _tokenServico.GerarToken(usuarioDTO);

            return Ok(new
            {
                usuarioDTO,
                token
            });
        }
        return BadRequest("Dados Incorretos");
    }
}
