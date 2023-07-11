using Microsoft.EntityFrameworkCore;
using Projeto.API.DataContext;
using Projeto.API.Models;
using Projeto.API.Repositorio.Interface;

namespace Projeto.API.Repositorio;

public class ItemArquivoRepositorio : IItemArquivoRepositorio
{
    private readonly AppDbContext _appDbContext;

    public ItemArquivoRepositorio(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<ItemArquivo>> PegarTodos(int pagina, int tamanho, string pesquisa)
    {
        var itemArquivos = await _appDbContext.ItemArquivos
            .Where(w => w.Descricao.Contains(pesquisa))
            .OrderBy(o => o.Descricao)
            .Skip((pagina - 1) * tamanho)
            .Take(tamanho)
            .ToListAsync();

        return itemArquivos;

    }
    public async Task<ItemArquivo> PegarPorId(int id)
    {
        var itemArquivo = await _appDbContext.ItemArquivos
            .Where(w => w.Id == id)
            .FirstOrDefaultAsync();

        if (itemArquivo is not null)
        {
            return itemArquivo;
        }
        else
        {
            return new ItemArquivo();
        }
    }
    public async Task<ItemArquivo> Criar(ItemArquivo itemArquivo)
    {
        if (itemArquivo is not null)
        {
            _appDbContext.ItemArquivos.Add(itemArquivo);
            await _appDbContext.SaveChangesAsync();
            return itemArquivo;

        }
        return new ItemArquivo();
    }
    public async Task<ItemArquivo> Atualizar(ItemArquivo itemArquivo)
    {
        if (itemArquivo is not null)
        {
            _appDbContext.Entry(itemArquivo).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return itemArquivo;
        }
        return new ItemArquivo();
    }
    public async Task<ItemArquivo> Deletar(int id)
    {
        var itemArquivo = await PegarPorId(id);
        if (itemArquivo is not null)
        {
            _appDbContext.Remove(itemArquivo);
            await _appDbContext.SaveChangesAsync();
            return itemArquivo;
        }
        return new ItemArquivo();
    }

    public async Task<int> TotalDados(string pesquisa)
    {
        var totalItemArquivo = await _appDbContext.ItemArquivos
            .Where(w => w.Descricao.Contains(pesquisa))
            .CountAsync();

        return totalItemArquivo;
    }
}
