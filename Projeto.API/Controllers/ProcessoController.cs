using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.API.Dtos;
using Projeto.API.Servico.Interface;

namespace Projeto.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProcessoController : ControllerBase
{
    private readonly IProcessoServico _processoServico;

    public ProcessoController(IProcessoServico processoServico)
    {
        _processoServico = processoServico;
    }
    [HttpGet]
    //[Authorize(Roles = "Administrador, Operador, Consultor")]
    public async Task<ActionResult<ProcessoOutputDTO>> PegarTodos([FromQuery] int pagina = 1, [FromQuery] int tamanho = 25, [FromQuery] string pesquisa = "")
    {
        var processos = await _processoServico.PegarTodos(pagina, tamanho, pesquisa);
        decimal totalDados = await _processoServico.TotalDados(pesquisa);
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
            dados = processos
        });
    }
    [HttpGet("{id:int}", Name = "PegarProcesso")]
    //[Authorize(Roles = "Administrador, Operador, Consultor")]
    public async Task<ActionResult<ProcessoOutputDTO>> PegarPorId(int id)
    {
        var processoDTO = await _processoServico.PegarPorId(id);
        if (processoDTO is not null)
        {
            return Ok(processoDTO);
        }
        return NotFound("Dados não encontrado");
    }
    [HttpPost]
    //[Authorize(Roles = "Administrador, Operador")]
    public async Task<ActionResult<ProcessoInputDTO>> Post([FromBody] ProcessoInputDTO processoDTO)
    {
        if (processoDTO is not null)
        {
            await _processoServico.Criar(processoDTO);
            return new CreatedAtRouteResult("PegarProcesso", new { id = processoDTO.Id }, processoDTO);
        }
        return BadRequest("Dados Incorretos");
    }
    [HttpPut("{id:int}")]
    //[Authorize(Roles = "Administrador, Operador")]
    public async Task<ActionResult<ProcessoInputDTO>> Put(int id, [FromBody] ProcessoInputDTO processoDTO)
    {
        if (id != processoDTO.Id)
        {
            return BadRequest("Dados Incorretos");
        }

        if (processoDTO is not null)
        {
            await _processoServico.Atualizar(processoDTO);
            return Ok(processoDTO);
        }
        return BadRequest("Dados Incorretos");
    }
    [HttpDelete("{id:int}")]
    //[Authorize(Roles = "Administrador")]
    public async Task<ActionResult<ProcessoOutputDTO>> Delete(int id)
    {
        var processoDTO = await _processoServico.PegarPorId(id);
        if (processoDTO is not null)
        {
            await _processoServico.Deletar(id);
            return Ok(processoDTO);
        }
        return NotFound("Dados Não Encontrado");
    }
}
