using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskli.Domain.Entities;

namespace Taskli.Infrastructure.Mappings;

public class PurchasePurposeMap : IEntityTypeConfiguration<PurchasePurposeEntity> {
    public void Configure(EntityTypeBuilder<PurchasePurposeEntity> builder) {
        builder.ToTable("tb_finalidadecompra");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(x => x.Description)
               .HasColumnName("descricao");
    }
}
