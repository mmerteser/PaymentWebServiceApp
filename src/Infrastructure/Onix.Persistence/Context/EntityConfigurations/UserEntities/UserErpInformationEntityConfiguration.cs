using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onix.Domain.Entities;
using Onix.Persistence.Context.EntityConfigurations.Common;

namespace Onix.Persistence.Context.EntityConfigurations.UserEntities
{
    public class UserErpInformationEntityConfiguration : BaseEntityConfiguration<UserErpInformation>
    {
        public override void Configure(EntityTypeBuilder<UserErpInformation> builder)
        {
            base.Configure(builder);

            builder.Property(i => i.ErpUsername)
                .HasColumnType(MssqlColumnTypes.Varchar)
                .HasMaxLength(200)
                .HasDefaultValue(String.Empty)
                .IsRequired();

            builder.Property(i => i.ErpUserGroupCode)
                .HasColumnType(MssqlColumnTypes.Varchar)
                .HasMaxLength(200)
                .HasDefaultValue(String.Empty)
                .IsRequired();

            builder.Property(i => i.ErpPassword)
                .HasColumnType(MssqlColumnTypes.Varchar)
                .HasMaxLength(200)
                .HasDefaultValue(String.Empty)
                .IsRequired();

            builder.Property(i => i.OfficeCode)
                .HasColumnType(MssqlColumnTypes.Varchar)
                .HasMaxLength(200)
                .HasDefaultValue(String.Empty)
                .IsRequired();

            builder.Property(i => i.SalepersonCode)
                .HasColumnType(MssqlColumnTypes.Varchar)
                .HasMaxLength(200)
                .HasDefaultValue(String.Empty)
                .IsRequired();

            builder.Property(i => i.StoreCode)
                .HasColumnType(MssqlColumnTypes.Varchar)
                .HasMaxLength(200)
                .HasDefaultValue(String.Empty)
                .IsRequired();

            builder.Property(i => i.WarehouseCode)
                .HasColumnType(MssqlColumnTypes.Varchar)
                .HasMaxLength(200)
                .HasDefaultValue(String.Empty)
                .IsRequired();

            builder.Property(i => i.POSTerminalId)
                .HasColumnType(MssqlColumnTypes.Int)
                .IsRequired();

            builder.ToTable("UserErpInformations", OnixContext.DEFAULT_SCHEME);
        }
    }
}
