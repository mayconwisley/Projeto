using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Projeto.API.Models.ConfiguracaoEntityType;

public class ItemArquivoConfiguracao : IEntityTypeConfiguration<ItemArquivo>
{
    public void Configure(EntityTypeBuilder<ItemArquivo> builder)
    {
        builder.Property(p => p.CodigoItem)
            .HasColumnType("VARCHAR(255)");
        builder.Property(p => p.Descricao)
            .HasColumnType("VARCHAR(500)")
            .IsRequired();
    }
}
