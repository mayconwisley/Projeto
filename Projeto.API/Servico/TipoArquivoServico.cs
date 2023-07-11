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
        var tipoArquivoEntity = await _tipoArquivoRespositorio.PegarTodos(pagina, tamanho, pesquisa);
        return _mapper.Map<IEnumerable<TipoArquivoDTO>>(tipoArquivoEntity);
    }
    public async Task<IEnumerable<TipoArquivoDTO>> PegarTodosAtivos(int pagina, int tamanho, string pesquisa)
    {
        var tipoArquivoEntityAtivo = await _tipoArquivoRespositorio.PegarTodosAtivos(pagina, tamanho, pesquisa);
        return _mapper.Map<IEnumerable<TipoArquivoDTO>>(tipoArquivoEntityAtivo);
    }
    public async Task<TipoArquivoDTO> PegarPorId(int id)
    {
        var tipoArquivoEntity = await _tipoArquivoRespositorio.PegarPorId(id);
        return _mapper.Map<TipoArquivoDTO>(tipoArquivoEntity);

    }
    public async Task Criar(TipoArquivoDTO tipoArquivo)
    {
        TipoArquivoDTO tipoArquivoDTO = new()
        {
            Id = tipoArquivo.Id,
            Descricao = tipoArquivo.Descricao,
            Guardar = tipoArquivo.Guardar,
            Tempo = tipoArquivo.Tempo,
            SuporteItem = tipoArquivo.SuporteItem,
            SuporteControleCaixa = tipoArquivo.SuporteControleCaixa,
            Ativo = tipoArquivo.Ativo
        };

        var tipoArquivoEntiry = _mapper.Map<TipoArquivo>(tipoArquivoDTO);
        await _tipoArquivoRespositorio.Criar(tipoArquivoEntiry);
        tipoArquivoDTO.Id = tipoArquivoEntiry.Id;

    }
    public async Task Atualizar(TipoArquivoDTO tipoArquivo)
    {
        TipoArquivoDTO tipoArquivoDTO = new()
        {
            Id = tipoArquivo.Id,
            Descricao = tipoArquivo.Descricao,
            Guardar = tipoArquivo.Guardar,
            Tempo = tipoArquivo.Tempo,
            SuporteItem = tipoArquivo.SuporteItem,
            SuporteControleCaixa = tipoArquivo.SuporteControleCaixa,
            Ativo = tipoArquivo.Ativo
        };

        var tipoArquivoEntiry = _mapper.Map<TipoArquivo>(tipoArquivoDTO);
        await _tipoArquivoRespositorio.Atualizar(tipoArquivoEntiry);
    }
    public async Task Deletar(int id)
    {
        var tipoArquivoEntiry = PegarPorId(id).Result;
        if (tipoArquivoEntiry is not null)
        {
            await _tipoArquivoRespositorio.Deletar(tipoArquivoEntiry.Id);
        }
    }
    public async Task<int> TotalDados(string pesquisa)
    {
        var totalTipoArquivo = await _tipoArquivoRespositorio.TotalDados(pesquisa);
        return totalTipoArquivo;
    }
}
