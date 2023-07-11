using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Projeto.API.Models.ConfiguracaoEntityType;

public class ArquivoConfiguracao : IEntityTypeConfiguration<Arquivo>
{
    public void Configure(EntityTypeBuilder<Arquivo> builder)
    {
        builder.Property(p => p.Descricao)
             .HasColumnType("VARCHAR(500)")
             .IsRequired();
        builder.Property(p => p.Pratelheira)
            .HasColumnType("VARCHAR(10)");
        builder.Property(p => p.PratelheiraLinha)
            .HasColumnType("VARCHAR(10)");
        builder.Property(p => p.PratelheiraColuna)
            .HasColumnType("VARCHAR(10)");
        builder.Property(p => p.Armario)
            .HasColumnType("VARCHAR(10)");
        builder.Property(p => p.Gaveta)
            .HasColumnType("VARCHAR(10)");
        builder.Property(p => p.PrimeiroUsuarioCadastro)
            .HasColumnType("VARCHAR(255)")
            .IsRequired();
        builder.Property(p => p.UltimoUsuarioAtualizar)
            .HasColumnType("VARCHAR(255)")
            .IsRequired();
        builder.Property(p => p.Competencia)
            .HasColumnType("DATETIME")
            .IsRequired();
        builder.Property(p => p.DataCadastro)
            .HasColumnType("DATETIME")
            .IsRequired();
        builder.Property(p => p.DataUltimaAtualizacao)
            .HasColumnType("DATETIME")
            .IsRequired();

    }
}
