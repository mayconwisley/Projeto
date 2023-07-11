using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Projeto.API.Models.ConfiguracaoEntityType;

public class ProcessoConfiguracao : IEntityTypeConfiguration<Processo>
{
    public void Configure(EntityTypeBuilder<Processo> builder)
    {
        builder.Property(p => p.ParaQuem)
            .HasColumnType("VARCHAR(255)")
            .IsRequired();
        builder.Property(p => p.Descricao)
            .HasColumnType("VARCHAR(255)")
            .IsRequired();
        builder.Property(p => p.Status)
            .HasColumnType("VARCHAR(255)")
            .IsRequired();
        builder.Property(p => p.DataEnvio)
            .HasColumnType("DATETIME")
            .IsRequired();
    }
}
