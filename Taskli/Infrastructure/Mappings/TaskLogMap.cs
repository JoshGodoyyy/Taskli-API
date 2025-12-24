using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskli.Domain.Entities;

namespace Taskli.Infrastructure.Mappings;

public class TaskLogMap : IEntityTypeConfiguration<TaskLogEntity> {
    public void Configure(EntityTypeBuilder<TaskLogEntity> builder) {
        builder.ToTable("tb_logtarefa");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.TaskId)
            .HasColumnName("idTarefa")
            .IsRequired();

        builder.Property(x => x.Start)
            .HasColumnName("inicio")
            .IsRequired();

        builder.Property(x => x.End)
            .HasColumnName("termino");
    }
}
