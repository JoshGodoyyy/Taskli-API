using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskli.Domain.Entities;

namespace Taskli.Infrastructure.Mappings;

public class SupplierMap : IEntityTypeConfiguration<SupplierEntity> {
    public void Configure(EntityTypeBuilder<SupplierEntity> builder) {
        builder.ToTable("tb_fornecedor");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("id");

        builder.Property(x => x.TradeName)
            .HasColumnName("fantasia");

        builder.Property(x => x.CorporateName)
            .HasColumnName("razaoSocial");

        builder.Property(x => x.CNPJ)
            .HasColumnName("cnpj");

        builder.Property(x => x.ClassId)
            .HasColumnName("idClasse");
    }
}
