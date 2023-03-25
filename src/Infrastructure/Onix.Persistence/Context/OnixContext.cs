using Microsoft.EntityFrameworkCore;
using Onix.Domain.Entities;
using Onix.Domain.Entities.Common;
using System.Reflection;

namespace Onix.Persistence.Context
{
    public class OnixContext : DbContext
    {
        public const string DEFAULT_SCHEME = "dbo";
        public const string BASETABLE_SCHEME = "base";
        public OnixContext()
        {

        }
        public OnixContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserMenu> UserMenus { get; set; }
        public DbSet<UserErpInformation> UserErpInformations { get; set; }
        public DbSet<ApplicationMenu> ApplicationMenu { get; set; }
        public DbSet<CompanyInformation> CompanyInformations { get; set; }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeChange();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeChange();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeChange();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeChange()
        {
            var datas = ChangeTracker
                 .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Modified:
                        data.Entity.UpdatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        data.Entity.CreatedDate = DateTime.UtcNow; 
                        data.Entity.UpdatedDate = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
