using finance_backend.Application.Repositories;
using finance_backend.DataAccess.Models.Data_access.Repository;
using Microsoft.EntityFrameworkCore;

namespace finance_backend.DataAccess.Models.Data_access;

public static class DataAccessModule
{
    public static IServiceCollection AddDataAccessModule(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationContext>(p =>
        {
            p.UseNpgsql(connectionString);
        });

        services
            .AddScoped<IRepository<Domain.User, Guid>, Repository<Domain.User, Guid>>();
            


        return services;
    }

}