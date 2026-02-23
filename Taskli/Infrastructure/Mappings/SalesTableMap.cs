using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskli.Domain.Entities;

namespace Taskli.Infrastructure.Mappings;

public class SalesTableMap : IEntityTypeConfiguration<SalesTableEntity> {
    public void Configure(EntityTypeBuilder<SalesTableEntity> builder) {
        builder.ToTable("tb_tabelavendas");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("id");

        builder.Property(x => x.InternalTableId)
            .HasColumnName("idTabelaInterna");

        builder.Property(x => x.Description)
            .HasColumnName("descricao");

        builder.Property(x => x.Inactive)
            .HasColumnName("inativa");
    }
}
