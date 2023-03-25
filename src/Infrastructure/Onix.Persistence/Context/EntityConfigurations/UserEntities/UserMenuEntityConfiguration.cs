using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onix.Domain.Entities;
using Onix.Persistence.Context.EntityConfigurations.Common;
using System.Reflection.Emit;

namespace Onix.Persistence.Context.EntityConfigurations.UserEntities
{
    public class UserMenuEntityConfiguration : BaseEntityConfiguration<UserMenu>
    {
        public override void Configure(EntityTypeBuilder<UserMenu> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserMenus)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.ApplicationMenu)
                .WithMany(x => x.UserMenus)
                .HasForeignKey(x => x.MenuId);

            builder.Property(i => i.Permission)
                .HasColumnType(MssqlColumnTypes.Boolean)
                .HasDefaultValue(true)
                .IsRequired();

            builder.ToTable("UserMenu", OnixContext.DEFAULT_SCHEME);

        }
    }
}
