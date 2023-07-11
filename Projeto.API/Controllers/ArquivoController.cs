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

    public ArquivoController(IArquivoServico tipoArquivoServico)
    {
        _arquivoServico = tipoArquivoServico;
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
    public async Task<ActionResult<ArquivoInputDTO>> Post([FromBody] ArquivoInputDTO tipoArquivo)
    {
        if (tipoArquivo is not null)
        {
            await _arquivoServico.Criar(tipoArquivo);
            return new CreatedAtRouteResult("PegarArquivo", new { id = tipoArquivo.Id }, tipoArquivo);
        }
        return BadRequest("Dados Incorretos");
    }
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Administrador, Operador")]
    public async Task<ActionResult<ArquivoInputDTO>> Put(int id, [FromBody] ArquivoInputDTO tipoArquivo)
    {
        if (id != tipoArquivo.Id)
        {
            return BadRequest("Dados Incorretos");
        }

        if (tipoArquivo is not null)
        {
            await _arquivoServico.Atualizar(tipoArquivo);
            return Ok(tipoArquivo);
        }
        return BadRequest("Dados Incorretos");
    }
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult<ArquivoOutputDTO>> Delete(int id)
    {
        var tipoArquivo = await _arquivoServico.PegarPorId(id);
        if (tipoArquivo is not null)
        {
            await _arquivoServico.Deletar(id);
            return Ok(tipoArquivo);
        }
        return NotFound("Dados Não Encontrado");
    }

}
