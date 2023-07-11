using Microsoft.EntityFrameworkCore;
using Projeto.API.DataContext;
using Projeto.API.Models;
using Projeto.API.Repositorio.Interface;

namespace Projeto.API.Repositorio;

public class ControleCaixaRepositorio : IControleCaixaRepositorio
{
    private readonly AppDbContext _appDbContext;

    public ControleCaixaRepositorio(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<ControleCaixa>> PegarTodos(int pagina, int tamanho, string pesquisa)
    {
        var controleCaixas = await _appDbContext.ControleCaixas
            .OrderBy(o => o.TipoArquivo.Descricao)
            .Skip((pagina - 1) * tamanho)
            .Take(tamanho)
            .ToListAsync();

        return controleCaixas;
    }

    public async Task<ControleCaixa> PegarPorId(int id)
    {
        var controleCaixa = await _appDbContext.ControleCaixas
            .Where(w => w.Id == id)
            .FirstOrDefaultAsync();

        if (controleCaixa is not null)
        {
            return controleCaixa;
        }
        else
        {
            return new ControleCaixa();
        }
    }
    public async Task<ControleCaixa> Criar(ControleCaixa controleCaixa)
    {
        if (controleCaixa is not null)
        {
            _appDbContext.ControleCaixas.Add(controleCaixa);
            await _appDbContext.SaveChangesAsync();
            return controleCaixa;

        }
        return new ControleCaixa();
    }
    public async Task<ControleCaixa> Atualizar(ControleCaixa controleCaixa)
    {
        if (controleCaixa is not null)
        {
            _appDbContext.Entry(controleCaixa).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return controleCaixa;
        }
        return new ControleCaixa();
    }
    public async Task<ControleCaixa> Deletar(int id)
    {
        var controleCaixa = await PegarPorId(id);
        if (controleCaixa is not null)
        {
            _appDbContext.Remove(controleCaixa);
            await _appDbContext.SaveChangesAsync();
            return controleCaixa;
        }
        return new ControleCaixa();
    }

    public async Task<int> TotalDados(string pesquisa)
    {
        var totalControleCaixa = await _appDbContext.ControleCaixas
            .CountAsync();

        return totalControleCaixa;
    }
}
