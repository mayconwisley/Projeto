using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.API.Dtos;
using Projeto.API.Servico.Interface;

namespace Projeto.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoArquivoController : ControllerBase
{
    private readonly ITipoArquivoServico _tipoArquivoServico;

    public TipoArquivoController(ITipoArquivoServico tipoArquivoServico)
    {
        _tipoArquivoServico = tipoArquivoServico;
    }
    [HttpGet("Ativos")]
    //[Authorize(Roles = "Administrador, Operador, Consultor")]
    public async Task<ActionResult<TipoArquivoDTO>> PegarTodosAtivos([FromQuery] int pagina = 1, [FromQuery] int tamanho = 25, [FromQuery] string pesquisa = "")
    {
        var tipoArquivoDTO = await _tipoArquivoServico.PegarTodosAtivos(pagina, tamanho, pesquisa);
        decimal totalDados = await _tipoArquivoServico.TotalDados(pesquisa);
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
            dados = tipoArquivoDTO
        });
    }
    [HttpGet]
    //[Authorize(Roles = "Administrador, Operador, Consultor")]
    public async Task<ActionResult<TipoArquivoDTO>> PegarTodos([FromQuery] int pagina = 1, [FromQuery] int tamanho = 25, [FromQuery] string pesquisa = "")
    {
        var tipoArquivoDTO = await _tipoArquivoServico.PegarTodos(pagina, tamanho, pesquisa);
        decimal totalDados = await _tipoArquivoServico.TotalDados(pesquisa);
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
            dados = tipoArquivoDTO
        });
    }
    [HttpGet("{id:int}", Name = "PegarTipoArquivo")]
    //[Authorize(Roles = "Administrador, Operador, Consultor")]
    public async Task<ActionResult<TipoArquivoDTO>> PegarPorId(int id)
    {
        var tipoArquivoDTO = await _tipoArquivoServico.PegarPorId(id);
        if (tipoArquivoDTO is not null)
        {
            return Ok(tipoArquivoDTO);
        }
        return NotFound("Dados não encontrado");
    }
    [HttpPost]
    //[Authorize(Roles = "Administrador, Operador")]
    public async Task<ActionResult<TipoArquivoDTO>> Post([FromBody] TipoArquivoDTO tipoArquivoDTO)
    {
        if (tipoArquivoDTO is not null)
        {
            await _tipoArquivoServico.Criar(tipoArquivoDTO);
            return new CreatedAtRouteResult("PegarTipoArquivo", new { id = tipoArquivoDTO.Id }, tipoArquivoDTO);
        }
        return BadRequest("Dados Incorretos");
    }
    [HttpPut("{id:int}")]
    //[Authorize(Roles = "Administrador, Operador")]
    public async Task<ActionResult<TipoArquivoDTO>> Put(int id, [FromBody] TipoArquivoDTO tipoArquivoDTO)
    {
        if (id != tipoArquivoDTO.Id)
        {
            return BadRequest("Dados Incorretos");
        }

        if (tipoArquivoDTO is not null)
        {
            await _tipoArquivoServico.Atualizar(tipoArquivoDTO);
            return Ok(tipoArquivoDTO);
        }
        return BadRequest("Dados Incorretos");
    }
    [HttpDelete("{id:int}")]
    //[Authorize(Roles = "Administrador")]
    public async Task<ActionResult<TipoArquivoDTO>> Delete(int id)
    {
        var tipoArquivoDTO = await _tipoArquivoServico.PegarPorId(id);
        if (tipoArquivoDTO is not null)
        {
            await _tipoArquivoServico.Deletar(id);
            return Ok(tipoArquivoDTO);
        }
        return NotFound("Dados Não Encontrado");
    }
}
