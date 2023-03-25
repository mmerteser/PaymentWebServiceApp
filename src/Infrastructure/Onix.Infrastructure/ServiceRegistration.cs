using Microsoft.Extensions.DependencyInjection;
using Onix.Application.Abstractions.Services.IntegratedApplicationServices;
using Onix.Integration.Factory;
using Onix.Application.Utilities.HttpService;
using Onix.Infrastructure.Utilities.HttpService;
using Onix.Integration.NebimV3;
using Onix.Application.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Onix.Integration.PaymentServices.Paynet;

namespace Onix.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastuctureService(this IServiceCollection services)
        {
            services.AddScoped<IHttpService, HttpService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IIntegratedApplicationFactory>((serviceProvider) => new IntegratedApplicationFactory(serviceProvider));
            services.AddScoped<NebimV3Service>()
                .AddScoped<IIntegratedApplicationService, NebimV3Service>(s => s.GetService<NebimV3Service>());

            services.AddScoped<IPaynetService, PaynetService>();
        }
    }
}
