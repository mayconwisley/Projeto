using Microsoft.EntityFrameworkCore;
using Projeto.API.DataContext;
using Projeto.API.Models;
using Projeto.API.Repositorio.Interface;

namespace Projeto.API.Repositorio;

public class TipoArquivoRepositorio : ITipoArquivoRepositorio
{
    private readonly AppDbContext _appDbContext;

    public TipoArquivoRepositorio(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<TipoArquivo>> PegarTodos(int pagina, int tamanho, string pesquisa)
    {
        var listTipoArquivo = await _appDbContext.TipoArquivos
            .Where(w => w.Descricao.Contains(pesquisa))
            .OrderBy(o => o.Descricao)
            .Skip((pagina - 1) * tamanho)
            .Take(tamanho)
            .ToListAsync();

        return listTipoArquivo;

    }
    public async Task<IEnumerable<TipoArquivo>> PegarTodosAtivos(int pagina, int tamanho, string pesquisa)
    {
        var listTipoArquivoAtivo = await _appDbContext.TipoArquivos
            .Where(w => w.Descricao.Contains(pesquisa) &&
                        w.Ativo == true)
            .OrderBy(o => o.Descricao)
            .Skip((pagina - 1) * tamanho)
            .Take(tamanho)
            .ToListAsync();

        return listTipoArquivoAtivo;
    }
    public async Task<TipoArquivo> PegarPorId(int id)
    {
        var tipoArquivo = await _appDbContext.TipoArquivos
            .Where(w => w.Id == id)
            .FirstOrDefaultAsync();

        if (tipoArquivo is not null)
        {
            return tipoArquivo;
        }
        else
        {
            return new TipoArquivo();
        }
    }
    public async Task<TipoArquivo> Criar(TipoArquivo tipoArquivo)
    {
        if (tipoArquivo is not null)
        {
            _appDbContext.TipoArquivos.Add(tipoArquivo);
            await _appDbContext.SaveChangesAsync();
            return tipoArquivo;

        }
        return new TipoArquivo();
    }
    public async Task<TipoArquivo> Atualizar(TipoArquivo tipoArquivo)
    {
        if (tipoArquivo is not null)
        {
            _appDbContext.Entry(tipoArquivo).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return tipoArquivo;
        }
        return new TipoArquivo();
    }
    public async Task<TipoArquivo> Deletar(int id)
    {
        var tipoArquivo = await PegarPorId(id);
        if (tipoArquivo is not null)
        {
            _appDbContext.Remove(tipoArquivo);
            await _appDbContext.SaveChangesAsync();
            return tipoArquivo;
        }
        return new TipoArquivo();
    }

    public async Task<int> TotalDados(string pesquisa)
    {
        var totalTipoArquivo = await _appDbContext.TipoArquivos
            .Where(w => w.Descricao.Contains(pesquisa))
            .CountAsync();

        return totalTipoArquivo;
    }
}
