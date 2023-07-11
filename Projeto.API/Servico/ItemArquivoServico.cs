using AutoMapper;
using Projeto.API.Dtos;
using Projeto.API.Models;
using Projeto.API.Repositorio.Interface;
using Projeto.API.Servico.Interface;

namespace Projeto.API.Servico;

public class ItemArquivoServico : IItemArquivoServico
{
    private readonly IItemArquivoRepositorio _itemArquivoRepositorio;
    private readonly IMapper _mapper;

    public ItemArquivoServico(IItemArquivoRepositorio itemArquivoRepositorio, IMapper mapper)
    {
        _itemArquivoRepositorio = itemArquivoRepositorio;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ItemArquivoOutputDTO>> PegarTodos(int pagina, int tamanho, string pesquisa)
    {
        var itemArquivos = await _itemArquivoRepositorio.PegarTodos(pagina, tamanho, pesquisa);
        return _mapper.Map<IEnumerable<ItemArquivoOutputDTO>>(itemArquivos);
    }
    public async Task<ItemArquivoOutputDTO> PegarPorId(int id)
    {
        var itemArquivo = await _itemArquivoRepositorio.PegarPorId(id);
        return _mapper.Map<ItemArquivoOutputDTO>(itemArquivo);

    }
    public async Task Criar(ItemArquivoInputDTO itemArquivoDTO)
    {
        var itemArquivo = _mapper.Map<ItemArquivo>(itemArquivoDTO);
        await _itemArquivoRepositorio.Criar(itemArquivo);
        itemArquivoDTO.Id = itemArquivo.Id;

    }
    public async Task Atualizar(ItemArquivoInputDTO itemArquivoDTO)
    {
        var itemArquivo = _mapper.Map<ItemArquivo>(itemArquivoDTO);
        await _itemArquivoRepositorio.Atualizar(itemArquivo);
    }
    public async Task Deletar(int id)
    {
        var itemArquivoDTO = PegarPorId(id).Result;
        if (itemArquivoDTO is not null)
        {
            await _itemArquivoRepositorio.Deletar(itemArquivoDTO.Id);
        }
    }
    public async Task<int> TotalDados(string pesquisa)
    {
        var totalItemArquivo = await _itemArquivoRepositorio.TotalDados(pesquisa);
        return totalItemArquivo;
    }
}
