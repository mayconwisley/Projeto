using AutoMapper;
using Projeto.API.Dtos;
using Projeto.API.Models;
using Projeto.API.Repositorio.Interface;
using Projeto.API.Servico.Interface;

namespace Projeto.API.Servico;

public class TipoArquivoServico : ITipoArquivoServico
{
    private readonly ITipoArquivoRepositorio _tipoArquivoRespositorio;
    private readonly IMapper _mapper;

    public TipoArquivoServico(ITipoArquivoRepositorio tipoArquivoRespositorio, IMapper mapper)
    {
        _tipoArquivoRespositorio = tipoArquivoRespositorio;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TipoArquivoDTO>> PegarTodos(int pagina, int tamanho, string pesquisa)
    {
        var tipoArquivos = await _tipoArquivoRespositorio.PegarTodos(pagina, tamanho, pesquisa);
        return _mapper.Map<IEnumerable<TipoArquivoDTO>>(tipoArquivos);
    }
    public async Task<IEnumerable<TipoArquivoDTO>> PegarTodosAtivos(int pagina, int tamanho, string pesquisa)
    {
        var tipoArquivosAtivo = await _tipoArquivoRespositorio.PegarTodosAtivos(pagina, tamanho, pesquisa);
        return _mapper.Map<IEnumerable<TipoArquivoDTO>>(tipoArquivosAtivo);
    }
    public async Task<TipoArquivoDTO> PegarPorId(int id)
    {
        var tipoArquivo = await _tipoArquivoRespositorio.PegarPorId(id);
        return _mapper.Map<TipoArquivoDTO>(tipoArquivo);

    }
    public async Task Criar(TipoArquivoDTO tipoArquivoDTO)
    {
        var tipoArquivo = _mapper.Map<TipoArquivo>(tipoArquivoDTO);
        await _tipoArquivoRespositorio.Criar(tipoArquivo);
        tipoArquivoDTO.Id = tipoArquivo.Id;

    }
    public async Task Atualizar(TipoArquivoDTO tipoArquivoDTO)
    {
        var tipoArquivo = _mapper.Map<TipoArquivo>(tipoArquivoDTO);
        await _tipoArquivoRespositorio.Atualizar(tipoArquivo);
    }
    public async Task Deletar(int id)
    {
        var tipoArquivoDTO = PegarPorId(id).Result;
        if (tipoArquivoDTO is not null)
        {
            await _tipoArquivoRespositorio.Deletar(tipoArquivoDTO.Id);
        }
    }
    public async Task<int> TotalDados(string pesquisa)
    {
        var totalTipoArquivo = await _tipoArquivoRespositorio.TotalDados(pesquisa);
        return totalTipoArquivo;
    }
}
