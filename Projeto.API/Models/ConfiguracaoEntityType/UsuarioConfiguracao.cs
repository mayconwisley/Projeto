using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Projeto.API.Models.ConfiguracaoEntityType;

public class UsuarioConfiguracao : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasIndex(h => h.Login)
            .IsUnique();

        builder.Property(p => p.Login)
            .HasColumnType("VARCHAR(255)")
            .IsRequired();
        builder.Property(p => p.Nome)
            .HasColumnType("VARCHAR(255)")
            .IsRequired();
        builder.Property(p => p.Senha)
            .HasColumnType("VARCHAR(MAX)")
            .IsRequired();
    }
}
