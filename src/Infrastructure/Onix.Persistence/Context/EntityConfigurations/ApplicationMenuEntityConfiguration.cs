using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onix.Domain.Entities;
using Onix.Persistence.Context.EntityConfigurations.Common;

namespace Onix.Persistence.Context.EntityConfigurations
{
    public class ApplicationMenuEntityConfiguration : BaseEntityConfiguration<ApplicationMenu>
    {
        public override void Configure(EntityTypeBuilder<ApplicationMenu> builder)
        {
            base.Configure(builder);

            builder.Property(i => i.MenuCode)
                .HasColumnType(MssqlColumnTypes.Int)
                .IsRequired();

            builder.Property(i => i.ApplicationType)
                .HasColumnType(MssqlColumnTypes.Varchar)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(i => i.Name)
                .HasColumnType(MssqlColumnTypes.Varchar)
                .HasMaxLength(100)
                .IsRequired();
            
            builder.ToTable("ApplicationMenu", OnixContext.BASETABLE_SCHEME);
        }
    }
}
