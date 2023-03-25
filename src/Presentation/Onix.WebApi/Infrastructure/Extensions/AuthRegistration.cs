using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Onix.Application.Utilities.Security.Encryption;
using System.Security.Claims;
using System.Text;

namespace Onix.WebApi.Infrastructure.Extensions
{
    public static class AuthRegistration
    {
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.SaveToken = true;
                        options.TokenValidationParameters = new()
                        {
                            ValidateAudience = true,
                            ValidateIssuer = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,

                            ValidAudience = configuration["TokenOptions:Audience"],
                            ValidIssuer = configuration["TokenOptions:Issuer"],
                            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(configuration["TokenOptions:SecurityKey"]),
                            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,

                        };
                    });
        }
    }
}
