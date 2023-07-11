using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.API.Dtos;
using Projeto.API.Servico.Interface;

namespace Projeto.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemArquivoController : ControllerBase
{
    private readonly IItemArquivoServico _itemArquivoServico;

    public ItemArquivoController(IItemArquivoServico itemArquivoServico)
    {
        _itemArquivoServico = itemArquivoServico;
    }
    [HttpGet]
    [Authorize(Roles = "Administrador, Operador, Consultor")]
    public async Task<ActionResult<ItemArquivoOutputDTO>> PegarTodos([FromQuery] int pagina = 1, [FromQuery] int tamanho = 25, [FromQuery] string pesquisa = "")
    {
        var itemArquivos= await _itemArquivoServico.PegarTodos(pagina, tamanho, pesquisa);
        decimal totalDados = await _itemArquivoServico.TotalDados(pesquisa);
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
            dados = itemArquivos
        });
    }
    [HttpGet("{id:int}", Name = "PegarItemArquivo")]
    [Authorize(Roles = "Administrador, Operador, Consultor")]
    public async Task<ActionResult<ItemArquivoOutputDTO>> PegarPorId(int id)
    {
        var itemArquivo = await _itemArquivoServico.PegarPorId(id);
        if (itemArquivo is not null)
        {
            return Ok(itemArquivo);
        }
        return NotFound("Dados não encontrado");
    }
    [HttpPost]
    [Authorize(Roles = "Administrador, Operador")]
    public async Task<ActionResult<ItemArquivoInputDTO>> Post([FromBody] ItemArquivoInputDTO itemArquivo)
    {
        if (itemArquivo is not null)
        {
            await _itemArquivoServico.Criar(itemArquivo);
            return new CreatedAtRouteResult("PegarItemArquivo", new { id = itemArquivo.Id }, itemArquivo);
        }
        return BadRequest("Dados Incorretos");
    }
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Administrador, Operador")]
    public async Task<ActionResult<ItemArquivoInputDTO>> Put(int id, [FromBody] ItemArquivoInputDTO itemArquivo)
    {
        if (id != itemArquivo.Id)
        {
            return BadRequest("Dados Incorretos");
        }

        if (itemArquivo is not null)
        {
            await _itemArquivoServico.Atualizar(itemArquivo);
            return Ok(itemArquivo);
        }
        return BadRequest("Dados Incorretos");
    }
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult<ItemArquivoOutputDTO>> Delete(int id)
    {
        var itemArquivo = await _itemArquivoServico.PegarPorId(id);
        if (itemArquivo is not null)
        {
            await _itemArquivoServico.Deletar(id);
            return Ok(itemArquivo);
        }
        return NotFound("Dados Não Encontrado");
    }
}
