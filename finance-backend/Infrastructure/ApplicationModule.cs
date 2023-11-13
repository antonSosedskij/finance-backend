using finance_backend.Application.Services.Category.Implementations;
using finance_backend.Application.Services.Category.Interfaces;
using finance_backend.Application.Services.User.Implementaitions;
using finance_backend.Application.Services.User.Interfaces;

namespace finance_backend.Infrastructure;

public static class ApplicationModule
{
    public static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        services
            .AddScoped<IUserService, UserService>()
            .AddScoped<ICategoryService, CategoryService>();

        return services;
    }
}