using finance_backend.Application.Repositories;
using finance_backend.DataAccess.Models;
using finance_backend.Infrastructure.Data_access.Repository;
using Microsoft.EntityFrameworkCore;

namespace finance_backend.Infrastructure.Data_access;

public static class DataAccessModule
{
    public static IServiceCollection AddDataAccessModule(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationContext>(p =>
        {
            p.UseNpgsql(connectionString);
        });

        services
            .AddScoped<IRepository<Domain.User, Guid>, Repository<Domain.User, Guid>>()
            .AddScoped<ICategoryRepository, CategoryRepository>()
            .AddScoped<IBalanceRepository, BalanceRepository>()
            .AddScoped<IIncomesRepository, IncomeRepository>();
        
        return services;
    }

}