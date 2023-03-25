using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onix.Persistence.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OnixContext>
    {
        public OnixContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<OnixContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
