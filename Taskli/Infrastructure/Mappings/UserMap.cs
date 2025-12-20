using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskli.Domain.Entities;

namespace Taskli.Infrastructure.Mappings;

public class UserMap : IEntityTypeConfiguration<UserEntity> {
    public void Configure(EntityTypeBuilder<UserEntity> builder) {
        builder.ToTable("tb_usuario");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("nome");

        builder.Property(x => x.Password)
            .IsRequired()
            .HasColumnName("senha");
    }
}
