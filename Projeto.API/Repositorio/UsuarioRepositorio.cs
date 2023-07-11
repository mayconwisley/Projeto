using Microsoft.EntityFrameworkCore;
using Projeto.API.DataContext;
using Projeto.API.Models;
using Projeto.API.Repositorio.Interface;

namespace Projeto.API.Repositorio;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly AppDbContext _appDbContext;

    public UsuarioRepositorio(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<Usuario>> PegarTodos(int pagina, int tamanho, string pesquisa)
    {
        var usuarios = await _appDbContext.Usuarios
             .Where(w => w.Login.Contains(pesquisa) ||
                         w.Nome.Contains(pesquisa))
             .OrderBy(o => o.Nome)
             .Skip((pagina - 1) * tamanho)
             .Take(tamanho)
             .ToListAsync();
        return usuarios;
    }
    public async Task<IEnumerable<Usuario>> PegarTodosAtivos(int pagina, int tamanho, string pesquisa)
    {
        var usuarios = await _appDbContext.Usuarios
             .Where(w => (w.Login.Contains(pesquisa) ||
                         w.Nome.Contains(pesquisa)) &&
                         w.Ativo == true)
             .OrderBy(o => o.Nome)
             .Skip((pagina - 1) * tamanho)
             .Take(tamanho)
             .ToListAsync();
        return usuarios;
    }
    public async Task<Usuario> PegarPorId(int id)
    {

        var usuario = await _appDbContext.Usuarios
            .Where(w => w.Id == id)
            .FirstOrDefaultAsync();

        if (usuario is not null)
        {
            return usuario;
        }
        else
        {
            return new Usuario();
        }
    }
    public async Task<Usuario> PegarPorLogin(string login)
    {
        var usuario = await _appDbContext.Usuarios
            .Where(w => w.Login == login)
            .FirstOrDefaultAsync();
        Usuario usuario1 = new()
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Login = usuario.Login,
            Autorizacao = usuario.Autorizacao,
            Ativo = usuario.Ativo

        };

        if (usuario is not null)
        {
            return usuario1;
        }
        else
        {
            return new Usuario();
        }
    }
    public async Task<Usuario> Acessar(Acesso acesso)
    {
        var usuario = await _appDbContext.Usuarios
            .Where(w => w.Login == acesso.Usuario &&
                        w.Senha == acesso.Senha)
            .FirstOrDefaultAsync();

        if (usuario is not null)
        {
            return usuario;
        }

        return new Usuario();
    }

    public async Task<Usuario> Criar(Usuario usuario)
    {
        if (usuario is not null)
        {
            _appDbContext.Usuarios.Add(usuario);
            await _appDbContext.SaveChangesAsync();
            return usuario;
        }
        return new Usuario();
    }
    public async Task<Usuario> Atualizar(Usuario usuario)
    {
        if (usuario is not null)
        {
            _appDbContext.Entry(usuario).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            var user = PegarPorId(usuario.Id).Result;
            return user;
        }
        return new Usuario();
    }
    public async Task<Usuario> Deletar(int id)
    {
        var usuario = await PegarPorId(id);
        if (usuario is not null)
        {
            _appDbContext.Remove(usuario);
            await _appDbContext.SaveChangesAsync();
            return usuario;
        }
        return new Usuario();
    }
    public async Task<int> TotalDados(string pesquisa)
    {
        var totalUsuario = await _appDbContext.Usuarios
        .Where(w => w.Login.Contains(pesquisa) ||
                    w.Nome.Contains(pesquisa))
        .CountAsync();

        return totalUsuario;
    }


}
