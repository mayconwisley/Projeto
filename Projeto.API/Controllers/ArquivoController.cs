using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.API.Dtos;
using Projeto.API.Servico.Interface;

namespace Projeto.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArquivoController : ControllerBase
{
    private readonly IArquivoServico _arquivoServico;

    public ArquivoController(IArquivoServico arquivoServico)
    {
        _arquivoServico = arquivoServico;
    }
    [HttpGet("Ativos")]
    [Authorize(Roles = "Administrador, Operador, Consultor")]
    public async Task<ActionResult<ArquivoOutputDTO>> PegarTodosAtivos([FromQuery] int pagina = 1, [FromQuery] int tamanho = 25, [FromQuery] string pesquisa = "")
    {
        var arquivoDTO = await _arquivoServico.PegarTodosAtivos(pagina, tamanho, pesquisa);
        decimal totalDados = await _arquivoServico.TotalDados(pesquisa);
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
            dados = arquivoDTO
        });
    }
    [HttpGet]
    [Authorize(Roles = "Administrador, Operador, Consultor")]
    public async Task<ActionResult<ArquivoOutputDTO>> PegarTodos([FromQuery] int pagina = 1, [FromQuery] int tamanho = 25, [FromQuery] string pesquisa = "")
    {
        var arquivoDTO = await _arquivoServico.PegarTodos(pagina, tamanho, pesquisa);
        decimal totalDados = await _arquivoServico.TotalDados(pesquisa);
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
            dados = arquivoDTO
        });
    }
    [HttpGet("{id:int}", Name = "PegarArquivo")]
    [Authorize(Roles = "Administrador, Operador, Consultor")]
    public async Task<ActionResult<ArquivoOutputDTO>> PegarPorId(int id)
    {
        var arquivoDTO = await _arquivoServico.PegarPorId(id);
        if (arquivoDTO is not null)
        {
            return Ok(arquivoDTO);
        }
        return NotFound("Dados não encontrado");
    }
    [HttpPost]
    [Authorize(Roles = "Administrador, Operador")]
    public async Task<ActionResult<ArquivoInputDTO>> Post([FromBody] ArquivoInputDTO arquivoDTO)
    {
        if (arquivoDTO is not null)
        {
            await _arquivoServico.Criar(arquivoDTO);
            return new CreatedAtRouteResult("PegarArquivo", new { id = arquivoDTO.Id }, arquivoDTO);
        }
        return BadRequest("Dados Incorretos");
    }
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Administrador, Operador")]
    public async Task<ActionResult<ArquivoInputDTO>> Put(int id, [FromBody] ArquivoInputDTO arquivoDTO)
    {
        if (id != arquivoDTO.Id)
        {
            return BadRequest("Dados Incorretos");
        }

        if (arquivoDTO is not null)
        {
            await _arquivoServico.Atualizar(arquivoDTO);
            return Ok(arquivoDTO);
        }
        return BadRequest("Dados Incorretos");
    }
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult<ArquivoOutputDTO>> Delete(int id)
    {
        var arquivoDTO = await _arquivoServico.PegarPorId(id);
        if (arquivoDTO is not null)
        {
            await _arquivoServico.Deletar(id);
            return Ok(arquivoDTO);
        }
        return NotFound("Dados Não Encontrado");
    }

}
