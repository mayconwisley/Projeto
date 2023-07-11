using Microsoft.EntityFrameworkCore;
using Projeto.API.DataContext;
using Projeto.API.Models;
using Projeto.API.Repositorio.Interface;

namespace Projeto.API.Repositorio;

public class ProcessoRepositorio : IProcessoRepositorio
{
    private readonly AppDbContext _appDbContext;

    public ProcessoRepositorio(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<Processo>> PegarTodos(int pagina, int tamanho, string pesquisa)
    {
        var processos = await _appDbContext.Processos
            .Where(w => w.Descricao.Contains(pesquisa))
            .OrderBy(o => o.Descricao)
            .Skip((pagina - 1) * tamanho)
            .Take(tamanho)
            .ToListAsync();

        return processos;

    }
    public async Task<Processo> PegarPorId(int id)
    {
        var processo = await _appDbContext.Processos
            .Where(w => w.Id == id)
            .FirstOrDefaultAsync();

        if (processo is not null)
        {
            return processo;
        }
        else
        {
            return new Processo();
        }
    }
    public async Task<Processo> Criar(Processo processo)
    {
        if (processo is not null)
        {
            _appDbContext.Processos.Add(processo);
            await _appDbContext.SaveChangesAsync();
            return processo;

        }
        return new Processo();
    }
    public async Task<Processo> Atualizar(Processo processo)
    {
        if (processo is not null)
        {
            _appDbContext.Entry(processo).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return processo;
        }
        return new Processo();
    }
    public async Task<Processo> Deletar(int id)
    {
        var processo = await PegarPorId(id);
        if (processo is not null)
        {
            _appDbContext.Remove(processo);
            await _appDbContext.SaveChangesAsync();
            return processo;
        }
        return new Processo();
    }

    public async Task<int> TotalDados(string pesquisa)
    {
        var totalProcesso = await _appDbContext.Processos
            .Where(w => w.Descricao.Contains(pesquisa))
            .CountAsync();

        return totalProcesso;
    }
}
