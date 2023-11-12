using finance_backend.Application.Services.User.Implementaitions;
using finance_backend.Application.Services.User.Interfaces;

namespace finance_backend.DataAccess.Models;

public static class ApplicationModule
{
    public static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        services
            .AddScoped<IUserService, UserService>();

        return services;
    }
}