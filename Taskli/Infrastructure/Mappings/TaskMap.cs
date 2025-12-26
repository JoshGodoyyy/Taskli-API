using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskli.Domain.Entities;

namespace Taskli.Infrastructure.Mappings;

public class TaskMap : IEntityTypeConfiguration<TaskEntity> {
    public void Configure(EntityTypeBuilder<TaskEntity> builder) {
        builder.ToTable("tb_tarefas");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Title)
            .HasColumnName("nomeTarefa")
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName("descricao");

        builder.Property(x => x.StartDate)
            .HasColumnName("dataInicial");

        builder.Property(x => x.EndDate)
            .HasColumnName("dataFinal");

        builder.Property(x => x.AffectsDeadline)
            .HasColumnName("impactaPrazo");

        builder.Property(x => x.CreatorId)
            .HasColumnName("idCriador");

        builder.Property(x => x.AssignedUserId)
            .HasColumnName("idUsuarioExecucao");

        builder.Property(x => x.ExecutionStreet)
            .HasColumnName("logradouroExecucao")
            .IsRequired()
            .HasDefaultValue(string.Empty);

        builder.Property(x => x.ExecutionNumber)
            .HasColumnName("numeroExecucao")
            .HasDefaultValue(string.Empty);

        builder.Property(x => x.ExecutionComplement)
            .HasColumnName("complementoExecucao");

        builder.Property(x => x.ExecutionNeighborhood)
            .HasColumnName("bairroExecucao")
            .IsRequired()
            .HasDefaultValue(string.Empty);

        builder.Property(x => x.ExecutionCity)
            .HasColumnName("cidadeExecucao")
            .IsRequired()
            .HasDefaultValue(string.Empty);

        builder.Property(x => x.ExecutionState)
            .HasColumnName("estadoExecucao")
            .IsRequired()
            .HasDefaultValue(string.Empty);

        builder.Property(x => x.ExecutionZipCode)
            .HasColumnName("cepExecucao");

        builder.Property(x => x.Latitude)
            .HasColumnName("latitude");

        builder.Property(x => x.Longitude)
            .HasColumnName("longitude");

        builder.Property(x => x.ClientId)
            .HasColumnName("idCliente")
            .IsRequired();

        builder.HasOne(x => x.Client)
            .WithMany(x => x.Tasks)
            .IsRequired();

        builder.Property(x => x.Finished)
            .HasColumnName("finalizada");

        builder.HasMany(x => x.TaskLogs)
            .WithOne(x => x.Task);
    }
}
