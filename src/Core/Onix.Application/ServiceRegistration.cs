using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Onix.Application.Features.Commands.Authentication.Login;
using Onix.Application.Utilities.Security.JWT;
using Onix.Application.Validators.Authentication;

namespace Onix.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
            services.AddAutoMapper(typeof(ServiceRegistration));
            services.AddScoped<ITokenHelper, JwtHelper>();
            services.AddHttpClient();
            services.AddMemoryCache();
        }

        public static void AddValidators(this IServiceCollection services)
        {
            services.AddSingleton<IValidator<LoginCommandRequest>, LoginValidator>();
        }
    }
}
