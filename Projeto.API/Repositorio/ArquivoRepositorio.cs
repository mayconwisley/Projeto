using Microsoft.EntityFrameworkCore;
using Projeto.API.DataContext;
using Projeto.API.Models;
using Projeto.API.Repositorio.Interface;

namespace Projeto.API.Repositorio;

public class ArquivoRepositorio : IArquivoRepositorio
{
    private readonly AppDbContext _appDbContext;

    public ArquivoRepositorio(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<Arquivo>> PegarTodos(int pagina, int tamanho, string pesquisa)
    {
        var arquivos = await _appDbContext.Arquivos
            .Where(w => w.Descricao.Contains(pesquisa))
            .OrderByDescending(o => o.Competencia)
            .ThenBy(t => t.Descricao)
            .Skip((pagina - 1) * tamanho)
            .Take(tamanho)
            .ToListAsync();

        return arquivos;

    }
    public async Task<IEnumerable<Arquivo>> PegarTodosAtivos(int pagina, int tamanho, string pesquisa)
    {
        var arquivosAtivo = await _appDbContext.Arquivos
            .Where(w => w.Descricao.Contains(pesquisa))
            .OrderByDescending(o => o.Competencia)
            .ThenBy(t => t.Descricao)
            .Skip((pagina - 1) * tamanho)
            .Take(tamanho)
            .ToListAsync();

        return arquivosAtivo;
    }
    public async Task<Arquivo> PegarPorId(int id)
    {
        var arquivo = await _appDbContext.Arquivos
            .Where(w => w.Id == id)
            .FirstOrDefaultAsync();

        if (arquivo is not null)
        {
            return arquivo;
        }
        else
        {
            return new Arquivo();
        }
    }
    public async Task<Arquivo> Criar(Arquivo arquivo)
    {
        if (arquivo is not null)
        {
            _appDbContext.Arquivos.Add(arquivo);
            await _appDbContext.SaveChangesAsync();
            return arquivo;

        }
        return new Arquivo();
    }
    public async Task<Arquivo> Atualizar(Arquivo arquivo)
    {
        if (arquivo is not null)
        {
            _appDbContext.Entry(arquivo).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return arquivo;
        }
        return new Arquivo();
    }
    public async Task<Arquivo> Deletar(int id)
    {
        var arquivo = await PegarPorId(id);
        if (arquivo is not null)
        {
            _appDbContext.Remove(arquivo);
            await _appDbContext.SaveChangesAsync();
            return arquivo;
        }
        return new Arquivo();
    }

    public async Task<int> TotalDados(string pesquisa)
    {
        var totalArquivo = await _appDbContext.Arquivos
            .Where(w => w.Descricao.Contains(pesquisa))
            .CountAsync();

        return totalArquivo;
    }
}
