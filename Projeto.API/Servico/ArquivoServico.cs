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

    public async Task<IEnumerable<ArquivoOutputDTO>> PegarTodos(int pagina, int tamanho, string pesquisa)
    {
        var arquivos = await _arquivoRepositorio.PegarTodos(pagina, tamanho, pesquisa);
        return _mapper.Map<IEnumerable<ArquivoOutputDTO>>(arquivos);
    }
    public async Task<IEnumerable<ArquivoOutputDTO>> PegarTodosAtivos(int pagina, int tamanho, string pesquisa)
    {
        var arquivosAtivo = await _arquivoRepositorio.PegarTodosAtivos(pagina, tamanho, pesquisa);
        return _mapper.Map<IEnumerable<ArquivoOutputDTO>>(arquivosAtivo);
    }
    public async Task<ArquivoOutputDTO> PegarPorId(int id)
    {
        var arquivo = await _arquivoRepositorio.PegarPorId(id);
        return _mapper.Map<ArquivoOutputDTO>(arquivo);

    }
    public async Task Criar(ArquivoInputDTO arquivoDTO)
    {
        var arquivo = _mapper.Map<Arquivo>(arquivoDTO);
        await _arquivoRepositorio.Criar(arquivo);
        arquivoDTO.Id = arquivo.Id;
    }
    public async Task Atualizar(ArquivoInputDTO arquivoDTO)
    {
        var arquivo = _mapper.Map<Arquivo>(arquivoDTO);
        await _arquivoRepositorio.Atualizar(arquivo);
    }
    public async Task Deletar(int id)
    {
        var arquivoDTO = PegarPorId(id).Result;
        if (arquivoDTO is not null)
        {
            await _arquivoRepositorio.Deletar(arquivoDTO.Id);
        }
    }
    public async Task<int> TotalDados(string pesquisa)
    {
        var totalArquivo = await _arquivoRepositorio.TotalDados(pesquisa);
        return totalArquivo;
    }
}
