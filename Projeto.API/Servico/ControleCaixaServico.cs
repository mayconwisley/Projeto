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

    public async Task<IEnumerable<ControleCaixaOutputDTO>> PegarTodos(int pagina, int tamanho, string pesquisa)
    {
        var controleCaixas = await _controleCaixaRepositorio.PegarTodos(pagina, tamanho, pesquisa);
        return _mapper.Map<IEnumerable<ControleCaixaOutputDTO>>(controleCaixas);
    }
    public async Task<ControleCaixaOutputDTO> PegarPorId(int id)
    {
        var controleCaixa = await _controleCaixaRepositorio.PegarPorId(id);
        return _mapper.Map<ControleCaixaOutputDTO>(controleCaixa);

    }
    public async Task Criar(ControleCaixaInputDTO controleCaixaDTO)
    {

        var controleCaixa = _mapper.Map<ControleCaixa>(controleCaixaDTO);
        await _controleCaixaRepositorio.Criar(controleCaixa);
        controleCaixaDTO.Id = controleCaixa.Id;

    }
    public async Task Atualizar(ControleCaixaInputDTO controleCaixaDTO)
    {
        var controleCaixa = _mapper.Map<ControleCaixa>(controleCaixaDTO);
        await _controleCaixaRepositorio.Atualizar(controleCaixa);
    }
    public async Task Deletar(int id)
    {
        var controleCaixaDTO = PegarPorId(id).Result;
        if (controleCaixaDTO is not null)
        {
            await _controleCaixaRepositorio.Deletar(controleCaixaDTO.Id);
        }
    }
    public async Task<int> TotalDados(string pesquisa)
    {
        var totalControleCaixa = await _controleCaixaRepositorio.TotalDados(pesquisa);
        return totalControleCaixa;
    }
}
