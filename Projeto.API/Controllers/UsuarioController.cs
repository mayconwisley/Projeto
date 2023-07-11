using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.API.Dtos;
using Projeto.API.Servico.Interface;

namespace Projeto.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioServico _usuarioServico;

    public UsuarioController(IUsuarioServico usuarioServico)
    {
        _usuarioServico = usuarioServico;
    }
    [HttpGet("Ativos")]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult<UsuarioOutputDTO>> PegarTodosAtivos([FromQuery] int pagina = 1, [FromQuery] int tamanho = 25, [FromQuery] string pesquisa = "")
    {
        var usuarioDTO = await _usuarioServico.PegarTodosAtivos(pagina, tamanho, pesquisa);
        decimal totalDados = await _usuarioServico.TotalDados(pesquisa);
        decimal totalPagina = (totalDados / tamanho) <= 0 ? 1 : Math.Ceiling((totalDados / tamanho));
        if (tamanho == 1)
        {
            totalPagina = totalDados;
        }

        return Ok(new
        {
            totalDados,
            pagina,
            totalPagina,
            tamanho,
            dados = usuarioDTO
        });
    }
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult<UsuarioOutputDTO>> PegarTodos([FromQuery] int pagina = 1, [FromQuery] int tamanho = 25, [FromQuery] string pesquisa = "")
    {
        var usuarioDTO = await _usuarioServico.PegarTodos(pagina, tamanho, pesquisa);
        decimal totalDados = await _usuarioServico.TotalDados(pesquisa);
        decimal totalPagina = (totalDados / tamanho) <= 0 ? 1 : Math.Ceiling((totalDados / tamanho));
        if (tamanho == 1)
        {
            totalPagina = totalDados;
        }

        return Ok(new
        {
            totalDados,
            pagina,
            totalPagina,
            tamanho,
            dados = usuarioDTO
        });
    }
    [HttpGet("{id:int}", Name = "PegarUsuario")]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult<UsuarioOutputDTO>> PegarPorId(int id)
    {
        var usuarioDTO = await _usuarioServico.PegarPorId(id);
        if (usuarioDTO is not null)
        {
            return Ok(usuarioDTO);
        }
        return NotFound("Dados não encontrado");
    }
    [HttpPost]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult<UsuarioInputDTO>> Post([FromBody] UsuarioInputDTO usuarioDTO)
    {
        if (usuarioDTO is not null)
        {
            await _usuarioServico.Criar(usuarioDTO);
            return new CreatedAtRouteResult("PegarUsuario", new { id = usuarioDTO.Id }, usuarioDTO);
        }
        return BadRequest("Dados Incorretos");
    }
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult<UsuarioInputDTO>> Put(int id, [FromBody] UsuarioInputDTO usuarioDTO)
    {
        if (id != usuarioDTO.Id)
        {
            return BadRequest("Dados Incorretos");
        }

        if (usuarioDTO is not null)
        {
            await _usuarioServico.Atualizar(usuarioDTO);
            return Ok(usuarioDTO);
        }
        return BadRequest("Dados Incorretos");
    }
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult<UsuarioOutputDTO>> Delete(int id)
    {
        var usuarioDTO = await _usuarioServico.PegarPorId(id);
        if (usuarioDTO is not null)
        {
            await _usuarioServico.Deletar(id);
            return Ok(usuarioDTO);
        }
        return NotFound("Dados Não Encontrado");
    }
}
