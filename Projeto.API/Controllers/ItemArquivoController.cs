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
    //[Authorize(Roles = "Administrador, Operador, Consultor")]
    public async Task<ActionResult<ItemArquivoOutputDTO>> PegarTodos([FromQuery] int pagina = 1, [FromQuery] int tamanho = 25, [FromQuery] string pesquisa = "")
    {
        var itemArquivos = await _itemArquivoServico.PegarTodos(pagina, tamanho, pesquisa);
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
    //[Authorize(Roles = "Administrador, Operador, Consultor")]
    public async Task<ActionResult<ItemArquivoOutputDTO>> PegarPorId(int id)
    {
        var itemArquivoDTO = await _itemArquivoServico.PegarPorId(id);
        if (itemArquivoDTO is not null)
        {
            return Ok(itemArquivoDTO);
        }
        return NotFound("Dados não encontrado");
    }
    [HttpPost]
    //[Authorize(Roles = "Administrador, Operador")]
    public async Task<ActionResult<ItemArquivoInputDTO>> Post([FromBody] ItemArquivoInputDTO itemArquivoDTO)
    {
        if (itemArquivoDTO is not null)
        {
            await _itemArquivoServico.Criar(itemArquivoDTO);
            return new CreatedAtRouteResult("PegarItemArquivo", new { id = itemArquivoDTO.Id }, itemArquivoDTO);
        }
        return BadRequest("Dados Incorretos");
    }
    [HttpPut("{id:int}")]
    //[Authorize(Roles = "Administrador, Operador")]
    public async Task<ActionResult<ItemArquivoInputDTO>> Put(int id, [FromBody] ItemArquivoInputDTO itemArquivoDTO)
    {
        if (id != itemArquivoDTO.Id)
        {
            return BadRequest("Dados Incorretos");
        }

        if (itemArquivoDTO is not null)
        {
            await _itemArquivoServico.Atualizar(itemArquivoDTO);
            return Ok(itemArquivoDTO);
        }
        return BadRequest("Dados Incorretos");
    }
    [HttpDelete("{id:int}")]
    //[Authorize(Roles = "Administrador")]
    public async Task<ActionResult<ItemArquivoOutputDTO>> Delete(int id)
    {
        var itemArquivoDTO = await _itemArquivoServico.PegarPorId(id);
        if (itemArquivoDTO is not null)
        {
            await _itemArquivoServico.Deletar(id);
            return Ok(itemArquivoDTO);
        }
        return NotFound("Dados Não Encontrado");
    }
}
