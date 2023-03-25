using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onix.Domain.Entities;
using Onix.Persistence.Context.EntityConfigurations.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onix.Persistence.Context.EntityConfigurations
{
    public class CompanyInformationEntityConfiguration : BaseEntityConfiguration<CompanyInformation>
    {
        public override void Configure(EntityTypeBuilder<CompanyInformation> builder)
        {
            base.Configure(builder);

            builder.Property(i => i.CompanyName)
                .HasColumnType(MssqlColumnTypes.Varchar)
                .HasMaxLength(400)
                .HasDefaultValue(String.Empty)
                .IsRequired();

            builder.Property(i => i.ServiceUrl)
                .HasColumnType(MssqlColumnTypes.Varchar)
                .HasMaxLength(200)
                .HasDefaultValue(String.Empty)
                .IsRequired();

            builder.Property(i => i.Username)
                .HasColumnType(MssqlColumnTypes.Varchar)
                .HasMaxLength(200)
                .HasDefaultValue(String.Empty)
                .IsRequired();

            builder.Property(i => i.Type)
                .HasColumnType(MssqlColumnTypes.Varchar)
                .HasMaxLength(10)
                .HasDefaultValue(String.Empty)
                .IsRequired();

            builder.Property(i => i.AuthenticationType)
                .HasColumnType(MssqlColumnTypes.Varchar)
                .HasMaxLength(10)
                .HasDefaultValue(String.Empty)
                .IsRequired();

            builder.Property(i => i.ApplicationName)
                .HasColumnType(MssqlColumnTypes.Varchar)
                .HasMaxLength(200)
                .HasDefaultValue(String.Empty)
                .IsRequired();

            builder.Property(i => i.Password)
                .HasColumnType(MssqlColumnTypes.Varchar)
                .HasMaxLength(200)
                .HasDefaultValue(String.Empty)
                .IsRequired();

            builder.Property(i => i.SecurityKey)
               .HasColumnType(MssqlColumnTypes.Varchar)
               .HasMaxLength(200)
               .HasDefaultValue(String.Empty)
               .IsRequired();

            builder.ToTable("CompanyInformations", OnixContext.DEFAULT_SCHEME);
        }
    }
}
