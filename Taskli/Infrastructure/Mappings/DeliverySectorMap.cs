using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskli.Domain.Entities;

namespace Taskli.Infrastructure.Mappings;

public class DeliverySectorMap : IEntityTypeConfiguration<DeliverySectorEntity> {
    public void Configure(EntityTypeBuilder<DeliverySectorEntity> builder) {
        builder.ToTable("tb_setorentrega");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Description)
            .HasColumnName("descricao");
    }
}
