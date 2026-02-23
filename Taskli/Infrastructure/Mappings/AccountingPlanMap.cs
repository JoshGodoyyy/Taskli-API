using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskli.Domain.Entities;

namespace Taskli.Infrastructure.Mappings;

public class AccountingPlanMap : IEntityTypeConfiguration<AccountingPlanEntity> {
    public void Configure(EntityTypeBuilder<AccountingPlanEntity> builder) {
        builder.ToTable("tb_planocontabil");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .HasColumnName("codigo");

        builder.Property(x => x.Description)
               .HasColumnName("descricao");
    }
}
