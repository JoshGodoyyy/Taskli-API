using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskli.Domain.Entities;

namespace Taskli.Infrastructure.Mappings;

public class PaymentMethodMap : IEntityTypeConfiguration<PaymentMethodEntity> {
    public void Configure(EntityTypeBuilder<PaymentMethodEntity> builder) {
        builder.ToTable("tb_formapagamento");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Description)
            .HasColumnName("descricao");
    }
}
