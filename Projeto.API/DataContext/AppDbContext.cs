using Microsoft.EntityFrameworkCore;
using Projeto.API.Models;
using Projeto.API.Ultilitario;
using System.Reflection;

namespace Projeto.API.DataContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<Usuario>().HasData(
            new Usuario
            {
                Id = 1,
                Nome = "Adminstrador",
                Login = "Admin",
                Ativo = true,
                Autorizacao = Models.Enum.AutorizacaoEnum.Administrador,
                Senha = SenhaHash.Gerar("Admin@")
            });
    }

    public DbSet<TipoArquivo> TipoArquivos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<ControleCaixa> ControleCaixas { get; set; }
    public DbSet<Arquivo> Arquivos { get; set; }
    public DbSet<ItemArquivo> ItemArquivos { get; set; }
    public DbSet<Processo> Processos { get; set; }



}
