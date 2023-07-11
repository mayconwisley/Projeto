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

    public ControleCaixaController(IControleCaixaServico tipoArquivoServico)
    {
        _controleCaixaServico = tipoArquivoServico;
    }
   
    [HttpGet]
    [Authorize(Roles = "Administrador, Operador, Consultor")]
    public async Task<ActionResult<ControleCaixaDTO>> PegarTodos([FromQuery] int pagina = 1, [FromQuery] int tamanho = 25, [FromQuery] string pesquisa = "")
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
    public async Task<ActionResult<ControleCaixaDTO>> PegarPorId(int id)
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
    public async Task<ActionResult<ControleCaixaDTO>> Post([FromBody] ControleCaixaDTO tipoArquivo)
    {
        if (tipoArquivo is not null)
        {
            await _controleCaixaServico.Criar(tipoArquivo);
            return new CreatedAtRouteResult("PegarControleCaixa", new { id = tipoArquivo.Id }, tipoArquivo);
        }
        return BadRequest("Dados Incorretos");
    }
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Administrador, Operador")]
    public async Task<ActionResult<ControleCaixaDTO>> Put(int id, [FromBody] ControleCaixaDTO tipoArquivo)
    {
        if (id != tipoArquivo.Id)
        {
            return BadRequest("Dados Incorretos");
        }

        if (tipoArquivo is not null)
        {
            await _controleCaixaServico.Atualizar(tipoArquivo);
            return Ok(tipoArquivo);
        }
        return BadRequest("Dados Incorretos");
    }
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult<ControleCaixaDTO>> Delete(int id)
    {
        var tipoArquivo = await _controleCaixaServico.PegarPorId(id);
        if (tipoArquivo is not null)
        {
            await _controleCaixaServico.Deletar(id);
            return Ok(tipoArquivo);
        }
        return NotFound("Dados Não Encontrado");
    }
}
