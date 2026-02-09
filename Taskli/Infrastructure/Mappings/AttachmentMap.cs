using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskli.Domain.Entities;

namespace Taskli.Infrastructure.Mappings;

public class AttachmentMap : IEntityTypeConfiguration<AttachmentEntity> {
    public void Configure(EntityTypeBuilder<AttachmentEntity> builder) {
        builder.ToTable("tb_anexostarefa");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(a => a.TaskId)
            .HasColumnName("idTarefa")
            .IsRequired();

        builder.Property(a => a.File)
            .HasColumnName("anexo")
            .HasColumnType("blob");

        builder.Property(a => a.MimeType)
            .HasColumnName("mime_type")
            .IsRequired();
    }
}
