using AutoMapper;
using Projeto.API.Dtos;
using Projeto.API.Models;
using Projeto.API.Repositorio.Interface;
using Projeto.API.Servico.Interface;

namespace Projeto.API.Servico;

public class ArquivoServico : IArquivoServico
{
    private readonly IArquivoRepositorio _arquivoRepositorio;
    private readonly IMapper _mapper;

    public ArquivoServico(IArquivoRepositorio arquivoRespositorio, IMapper mapper)
    {
        _arquivoRepositorio = arquivoRespositorio;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ArquivoDTO>> PegarTodos(int pagina, int tamanho, string pesquisa)
    {
        var arquivoEntity = await _arquivoRepositorio.PegarTodos(pagina, tamanho, pesquisa);
        return _mapper.Map<IEnumerable<ArquivoDTO>>(arquivoEntity);
    }
    public async Task<IEnumerable<ArquivoDTO>> PegarTodosAtivos(int pagina, int tamanho, string pesquisa)
    {
        var arquivoEntityAtivo = await _arquivoRepositorio.PegarTodosAtivos(pagina, tamanho, pesquisa);
        return _mapper.Map<IEnumerable<ArquivoDTO>>(arquivoEntityAtivo);
    }
    public async Task<ArquivoDTO> PegarPorId(int id)
    {
        var arquivoEntity = await _arquivoRepositorio.PegarPorId(id);
        return _mapper.Map<ArquivoDTO>(arquivoEntity);

    }
    public async Task Criar(ArquivoDTO arquivo)
    {
        var arquivoEntiry = _mapper.Map<Arquivo>(arquivo);
        await _arquivoRepositorio.Criar(arquivoEntiry);
        arquivo.Id = arquivoEntiry.Id;
    }
    public async Task Atualizar(ArquivoDTO arquivo)
    {
        var arquivoEntiry = _mapper.Map<Arquivo>(arquivo);
        await _arquivoRepositorio.Atualizar(arquivoEntiry);
    }
    public async Task Deletar(int id)
    {
        var arquivoEntiry = PegarPorId(id).Result;
        if (arquivoEntiry is not null)
        {
            await _arquivoRepositorio.Deletar(arquivoEntiry.Id);
        }
    }
    public async Task<int> TotalDados(string pesquisa)
    {
        var totalArquivo = await _arquivoRepositorio.TotalDados(pesquisa);
        return totalArquivo;
    }
}
