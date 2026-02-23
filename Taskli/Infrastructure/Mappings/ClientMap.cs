using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Taskli.Domain.Entities;
using Taskli.Domain.Enums;

namespace Taskli.Infrastructure.Mappings;

public class ClientMap : IEntityTypeConfiguration<ClientEntity> {
    public void Configure(EntityTypeBuilder<ClientEntity> builder) {
        builder.ToTable("tb_cliente");

        var legalEntityConverter = new ValueConverter<EPersonType, string>(
            v => v == EPersonType.Individual ? "F" : "J",
            v => v == "F" ? EPersonType.Individual : EPersonType.Company
        );

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.TradeName)
            .HasColumnName("fantasia");

        builder.Property(x => x.CorporateName)
            .HasColumnName("razaoSocial");

        builder.Property(x => x.PersonType)
            .HasColumnName("tipoPessoa")
            .IsRequired()
            .HasConversion(legalEntityConverter);

        builder.Property(x => x.CNPJ)
            .HasColumnName("cnpj");

        builder.Property(x => x.IE)
            .HasColumnName("ie")
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnName("email")
            .IsRequired();

        builder.Property(x => x.Phone)
            .HasColumnName("telefone")
            .IsRequired();

        builder.Property(x => x.Address)
            .HasColumnName("end_nomerua")
            .IsRequired();

        builder.Property(x => x.Number)
            .HasColumnName("end_numero");

        builder.Property(x => x.Complement)
            .HasColumnName("end_complemento");

        builder.Property(x => x.Neighborhood)
            .HasColumnName("end_bairro")
            .IsRequired();

        builder.Property(x => x.City)
            .HasColumnName("end_cidade")
            .IsRequired();

        builder.Property(x => x.State)
            .HasColumnName("end_estado")
            .IsRequired();

        builder.Property(x => x.CEP)
            .HasColumnName("end_cep")
            .IsRequired();

        builder.HasMany(x => x.Tasks)
            .WithOne(x => x.Client)
            .HasForeignKey(x => x.ClientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
