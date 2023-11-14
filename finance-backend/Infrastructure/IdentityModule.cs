using finance_backend.Application.Identity.Interfaces;
using finance_backend.DataAccess.Models.Identity;
using finance_backend.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace finance_backend.DataAccess.Models;

public static class IdentityModule
{
    public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();
            
            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }
}