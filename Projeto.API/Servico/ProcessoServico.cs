using AutoMapper;
using Projeto.API.Dtos;
using Projeto.API.Models;
using Projeto.API.Repositorio.Interface;
using Projeto.API.Servico.Interface;

namespace Projeto.API.Servico;

public class ProcessoServico : IProcessoServico
{
    private readonly IProcessoRepositorio _processoRepositorio;
    private readonly IMapper _mapper;

    public ProcessoServico(IProcessoRepositorio processoRepositorio, IMapper mapper)
    {
        _processoRepositorio = processoRepositorio;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProcessoOutputDTO>> PegarTodos(int pagina, int tamanho, string pesquisa)
    {
        var processos = await _processoRepositorio.PegarTodos(pagina, tamanho, pesquisa);
        return _mapper.Map<IEnumerable<ProcessoOutputDTO>>(processos);
    }

    public async Task<ProcessoOutputDTO> PegarPorId(int id)
    {
        var processo = await _processoRepositorio.PegarPorId(id);
        return _mapper.Map<ProcessoOutputDTO>(processo);
    }
    public async Task Criar(ProcessoInputDTO processoDTO)
    {
        var processo = _mapper.Map<Processo>(processoDTO);
        await _processoRepositorio.Criar(processo);
        processoDTO.Id = processo.Id;
    }
    public async Task Atualizar(ProcessoInputDTO processoDTO)
    {
        var processo = _mapper.Map<Processo>(processoDTO);
        await _processoRepositorio.Atualizar(processo);
    }
    public async Task Deletar(int id)
    {
        var processoDTO = PegarPorId(id).Result;
        if (processoDTO is not null)
        {
            await _processoRepositorio.Deletar(processoDTO.Id);
        }
    }
    public async Task<int> TotalDados(string pesquisa)
    {
        var totalProcesso = await _processoRepositorio.TotalDados(pesquisa);
        return totalProcesso;
    }
}
