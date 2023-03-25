using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Onix.Application.Utilities.Security.Hashing;
using Onix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onix.Persistence.Context.SeedData
{
    internal class SeedData
    {
        public async Task SeedAsync()
        {
            var dbContextBuilder = new DbContextOptionsBuilder()
                .UseSqlServer(Configuration.ConnectionString);

            var context = new OnixContext(dbContextBuilder.Options);


            #region CompanySeeding
            var company = await context.CompanyInformations.SingleOrDefaultAsync();

            if (company is null)
            {
                await context.CompanyInformations.AddAsync(new CompanyInformation { CompanyName = "DEFAULT COMPANY" });
                await context.SaveChangesAsync();
            }
            #endregion

            var user = await context.Users.SingleOrDefaultAsync(i => i.Username.Equals("admin"));

            if (user is null)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash("admin", out passwordHash, out passwordSalt);

                var firstCompany = await context.CompanyInformations.SingleOrDefaultAsync();

                await context.Users.AddAsync(
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Username = "admin",
                        FirstLastName = "admin admin",
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        CompanyId = firstCompany.Id,
                    });

                await context.SaveChangesAsync();
            }

        }
    }
}
