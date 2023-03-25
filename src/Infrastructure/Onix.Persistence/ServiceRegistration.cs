using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Onix.Application.Abstractions.Services.AuthServices;
using Onix.Application.Abstractions.Services.CompanyServices;
using Onix.Application.Repositories.CompanyInformationRepositories;
using Onix.Application.Repositories.UserErpInformationRepositories;
using Onix.Application.Repositories.UserMenuRepositories;
using Onix.Application.Repositories.UserRepositories;
using Onix.Persistence.Context;
using Onix.Persistence.Context.SeedData;
using Onix.Persistence.Repositories.CompanyInfornationRepositories;
using Onix.Persistence.Repositories.UserErpInformationRepositories;
using Onix.Persistence.Repositories.UserMenuRepositoies;
using Onix.Persistence.Repositories.UserRepositories;
using Onix.Persistence.Services.AuthServices;
using Onix.Persistence.Services.CompanyServices;

namespace Onix.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<OnixContext>(options => options.UseSqlServer(Configuration.ConnectionString));

            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IUserReadRepository, UserReadRepository>();

            services.AddScoped<IUserMenuWriteRepository, UserMenuWriteRepository>();
            services.AddScoped<IUserMenuReadRepository, UserMenuReadRepository>();

            services.AddScoped<ICompanyInformationReadRepository, CompanyInformationReadRepository>();
            services.AddScoped<ICompanyInformationWriteRepository, CompanyInformationWriteRepository>();

            services.AddScoped<IUserErpInformationReadRepository, UserErpInformationReadRepository>();
            services.AddScoped<IUserErpInformationWriteRepository, UserErpInformationWriteRepository>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICompanyService, CompanyService>();

            AddDataSeeding();
        }

        public static void AddDataSeeding()
        {
            var seedData = new SeedData();
            seedData.SeedAsync().GetAwaiter().GetResult();
        }
    }
}
