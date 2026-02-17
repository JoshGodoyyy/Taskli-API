using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;
using Taskli.Application.DTOs;
using Taskli.Domain.Entities;

namespace Taskli.Infrastructure.Mappings;

public class SettingsMap : IEntityTypeConfiguration<SettingsEntity>{
    public void Configure(EntityTypeBuilder<SettingsEntity> builder) {
        builder.ToTable("tb_configuracoes");

        var jsonOptions = new JsonSerializerOptions();

        builder.HasKey(x => x.Id);

        builder.Property(x => x.MinDistanceToExecute)
            .HasColumnName("distanciaMinimaExecTarefa");

        builder.Property(x => x.TaskRequiredFields)
            .HasColumnName("camposRequeridosTarefa")
            .HasConversion(
            v => JsonSerializer.Serialize(v, jsonOptions),
            v => string.IsNullOrEmpty(v)
            ? new List<RequirementResult>()
            : JsonSerializer.Deserialize<List<RequirementResult>>(v, jsonOptions)
        );
    }
}
