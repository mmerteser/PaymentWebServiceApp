using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onix.Domain.Entities.Common;
using Onix.Persistence.Context.EntityConfigurations.Common;

namespace Onix.Persistence.Context.EntityConfigurations
{
    public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id)
                .IsClustered();

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            builder.Property(x => x.CreatedDate)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnType(MssqlColumnTypes.DateTime)
                .HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdatedDate)
                .ValueGeneratedOnUpdate()
                .IsRequired()
                .HasColumnType(MssqlColumnTypes.DateTime)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
