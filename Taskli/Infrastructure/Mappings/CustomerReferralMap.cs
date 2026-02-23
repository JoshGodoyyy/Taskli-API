using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskli.Domain.Entities;

namespace Taskli.Infrastructure.Mappings;

public class CustomerReferralMap : IEntityTypeConfiguration<CustomerReferralEntity> {
    public void Configure(EntityTypeBuilder<CustomerReferralEntity> builder) {
        builder.ToTable("tb_indicacao_cliente");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(x => x.Description)
               .HasColumnName("descricao");
    }
}
