using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onix.Application.Utilities.Security.Hashing;
using Onix.Domain.Entities;
using Onix.Persistence.Context.EntityConfigurations.Common;

namespace Onix.Persistence.Context.EntityConfigurations.UserEntities
{
    public class UserEntityConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(i => i.Username)
                .HasColumnType(MssqlColumnTypes.Varchar)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(i => i.Username).IsUnique();

            builder.Property(i => i.FirstLastName)
                .HasColumnType(MssqlColumnTypes.Varchar)
                .HasMaxLength(100)
                .HasDefaultValue(String.Empty)
                .IsRequired();

            builder.HasIndex(i => i.FirstLastName);

            builder.Property(i => i.Email)
                .HasColumnType(MssqlColumnTypes.Varchar)
                .HasMaxLength(200)
                .HasDefaultValue(String.Empty)
                .IsRequired();

            builder.HasIndex(i => i.Email).IsUnique();

            builder.Property(i => i.LangCode)
                .HasColumnType(MssqlColumnTypes.Varchar)
                .HasMaxLength(5)
                .HasDefaultValue(MssqlColumnTypes.DefaultLangCode)
                .IsRequired();

            builder.Property(i => i.PasswordHash)
                .HasColumnType(MssqlColumnTypes.Binary)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(i => i.PasswordSalt)
                .HasColumnType(MssqlColumnTypes.Binary)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(i => i.IsBlocked)
                .HasColumnType(MssqlColumnTypes.Boolean)
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasOne(i => i.CompanyInformation)
                .WithMany(i => i.Users)
                .HasForeignKey(i => i.CompanyId);


            builder.ToTable("Users", OnixContext.DEFAULT_SCHEME);
        }
    }
}
