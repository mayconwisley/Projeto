using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Projeto.API.Models.ConfiguracaoEntityType;

public class TipoArquivoConfiguracao : IEntityTypeConfiguration<TipoArquivo>
{
    public void Configure(EntityTypeBuilder<TipoArquivo> builder)
    {
        builder.Property(p => p.Descricao)
            .HasColumnType("VARCHAR(500)")
            .IsRequired();
        builder.Property(p => p.Guardar)
            .HasDefaultValue(0);
    }
}
