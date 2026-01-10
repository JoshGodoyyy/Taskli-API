using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskli.Domain.Entities;

namespace Taskli.Infrastructure.Mappings;

public class MessageMap : IEntityTypeConfiguration<MessageEntity> {
    public void Configure(EntityTypeBuilder<MessageEntity> builder) {
        builder.ToTable("tb_mensagens_tarefa");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.TaskId)
            .HasColumnName("idTarefa")
            .IsRequired();

        builder.HasOne(x => x.Task)
            .WithMany(x => x.Messages)
            .HasForeignKey(x => x.TaskId);

        builder.Property(x => x.SenderId)
            .HasColumnName("idUsuario")
            .IsRequired();

        builder.HasOne(x => x.Sender)
            .WithMany()
            .HasForeignKey(x => x.SenderId);

        builder.Property(x => x.Text)
            .HasColumnName("mensagem")
            .IsRequired()
            .HasMaxLength(2000);

        builder.Property(x => x.SendedAt)
            .HasColumnName("data");
    }
}
