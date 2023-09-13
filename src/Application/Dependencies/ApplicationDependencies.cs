using System.Text;
using Application.Services;
using Application.Services.Contracts;
using Application.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Application.Dependencies
{
    public static class ApplicationDependencies
    {
        public static void InjectApplicationDependencies(this IServiceCollection serviceCollection)
        {
            AddServices(serviceCollection);
            AddAuthentication(serviceCollection);
            serviceCollection.AddMediatR(
                p => p.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        }
        private static void AddServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IBillService, BillService>();
            serviceCollection.AddScoped<ITokenService, TokenService>();
        }

        private static void AddAuthentication(IServiceCollection serviceCollection)
        {
            var key = Encoding.ASCII.GetBytes(TokenSettings.SecretKey);

            serviceCollection.AddAuthentication(opt => 
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt => 
            {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true, 
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateAudience = false,
                    ValidateIssuer = false   
                };
            });
        }
    }
}