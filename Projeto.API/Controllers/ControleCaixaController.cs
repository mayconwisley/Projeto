using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.API.Dtos;
using Projeto.API.Servico.Interface;

namespace Projeto.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ControleCaixaController : ControllerBase
{
    private readonly IControleCaixaServico _controleCaixaServico;

    public ControleCaixaController(IControleCaixaServico controleCaixaServico)
    {
        _controleCaixaServico = controleCaixaServico;
    }

    [HttpGet]
    [Authorize(Roles = "Administrador, Operador, Consultor")]
    public async Task<ActionResult<ControleCaixaOutputDTO>> PegarTodos([FromQuery] int pagina = 1, [FromQuery] int tamanho = 25, [FromQuery] string pesquisa = "")
    {
        var controleCaixaDTO = await _controleCaixaServico.PegarTodos(pagina, tamanho, pesquisa);
        decimal totalDados = await _controleCaixaServico.TotalDados(pesquisa);
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
            dados = controleCaixaDTO
        });
    }
    [HttpGet("{id:int}", Name = "PegarControleCaixa")]
    [Authorize(Roles = "Administrador, Operador, Consultor")]
    public async Task<ActionResult<ControleCaixaOutputDTO>> PegarPorId(int id)
    {
        var controleCaixaDTO = await _controleCaixaServico.PegarPorId(id);
        if (controleCaixaDTO is not null)
        {
            return Ok(controleCaixaDTO);
        }
        return NotFound("Dados não encontrado");
    }
    [HttpPost]
    [Authorize(Roles = "Administrador, Operador")]
    public async Task<ActionResult<ControleCaixaInputDTO>> Post([FromBody] ControleCaixaInputDTO controleCaixaDTO)
    {
        if (controleCaixaDTO is not null)
        {
            await _controleCaixaServico.Criar(controleCaixaDTO);
            return new CreatedAtRouteResult("PegarControleCaixa", new { id = controleCaixaDTO.Id }, controleCaixaDTO);
        }
        return BadRequest("Dados Incorretos");
    }
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Administrador, Operador")]
    public async Task<ActionResult<ControleCaixaInputDTO>> Put(int id, [FromBody] ControleCaixaInputDTO controleCaixaDTO)
    {
        if (id != controleCaixaDTO.Id)
        {
            return BadRequest("Dados Incorretos");
        }

        if (controleCaixaDTO is not null)
        {
            await _controleCaixaServico.Atualizar(controleCaixaDTO);
            return Ok(controleCaixaDTO);
        }
        return BadRequest("Dados Incorretos");
    }
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult<ControleCaixaOutputDTO>> Delete(int id)
    {
        var controleCaixaDTO = await _controleCaixaServico.PegarPorId(id);
        if (controleCaixaDTO is not null)
        {
            await _controleCaixaServico.Deletar(id);
            return Ok(controleCaixaDTO);
        }
        return NotFound("Dados Não Encontrado");
    }
}
