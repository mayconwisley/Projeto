using AutoMapper;
using Projeto.API.Dtos;
using Projeto.API.Models;
using Projeto.API.Repositorio.Interface;
using Projeto.API.Servico.Interface;

namespace Projeto.API.Servico;

public class ControleCaixaServico : IControleCaixaServico
{
    private readonly IControleCaixaRepositorio _controleCaixaRepositorio;
    private readonly IMapper _mapper;

    public ControleCaixaServico(IControleCaixaRepositorio controleCaixaRespositorio, IMapper mapper)
    {
        _controleCaixaRepositorio = controleCaixaRespositorio;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ControleCaixaDTO>> PegarTodos(int pagina, int tamanho, string pesquisa)
    {
        var controleCaixaEntity = await _controleCaixaRepositorio.PegarTodos(pagina, tamanho, pesquisa);
        return _mapper.Map<IEnumerable<ControleCaixaDTO>>(controleCaixaEntity);
    }
    public async Task<ControleCaixaDTO> PegarPorId(int id)
    {
        var controleCaixaEntity = await _controleCaixaRepositorio.PegarPorId(id);
        return _mapper.Map<ControleCaixaDTO>(controleCaixaEntity);

    }
    public async Task Criar(ControleCaixaDTO controleCaixa)
    {
        ControleCaixaDTO controleCaixaDTO = new()
        {
            Id = controleCaixa.Id,
            NumeroAtual = controleCaixa.NumeroAtual,
            TipoArquivoId = controleCaixa.TipoArquivoId,
            TipoArquivo = controleCaixa.TipoArquivo
        };

        var controleCaixaEntiry = _mapper.Map<ControleCaixa>(controleCaixaDTO);
        await _controleCaixaRepositorio.Criar(controleCaixaEntiry);
        controleCaixaDTO.Id = controleCaixaEntiry.Id;

    }
    public async Task Atualizar(ControleCaixaDTO controleCaixa)
    {
        ControleCaixaDTO controleCaixaDTO = new()
        {
            Id = controleCaixa.Id,
            NumeroAtual = controleCaixa.NumeroAtual,
            TipoArquivoId = controleCaixa.TipoArquivoId,
            TipoArquivo = controleCaixa.TipoArquivo
        };

        var controleCaixaEntiry = _mapper.Map<ControleCaixa>(controleCaixaDTO);
        await _controleCaixaRepositorio.Atualizar(controleCaixaEntiry);
    }
    public async Task Deletar(int id)
    {
        var controleCaixaEntiry = PegarPorId(id).Result;
        if (controleCaixaEntiry is not null)
        {
            await _controleCaixaRepositorio.Deletar(controleCaixaEntiry.Id);
        }
    }
    public async Task<int> TotalDados(string pesquisa)
    {
        var totalControleCaixa = await _controleCaixaRepositorio.TotalDados(pesquisa);
        return totalControleCaixa;
    }
}
