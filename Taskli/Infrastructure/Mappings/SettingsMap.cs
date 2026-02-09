using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskli.Domain.Entities;

namespace Taskli.Infrastructure.Mappings;

public class SettingsMap : IEntityTypeConfiguration<SettingsEntity>{
    public void Configure(EntityTypeBuilder<SettingsEntity> builder) {
        builder.ToTable("tb_configuracoes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.MinDistanceToExecute)
            .HasColumnName("distanciaMinimaExecTarefa");
    }
}
