using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskli.Domain.Entities;

namespace Taskli.Infrastructure.Mappings;

public class ClientClassMap : IEntityTypeConfiguration<ClientClassEntity> {
    public void Configure(EntityTypeBuilder<ClientClassEntity> builder) {
        builder.ToTable("tb_classecliente");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Description)
            .HasColumnName("descricao");
    }
}
