using finance_backend.Application.Services.Balance.Implementations;
using finance_backend.Application.Services.Balance.Interfaces;
using finance_backend.Application.Services.Category.Implementations;
using finance_backend.Application.Services.Category.Interfaces;
using finance_backend.Application.Services.Expense.Implementations;
using finance_backend.Application.Services.Expense.Interfaces;
using finance_backend.Application.Services.Income.Implementations;
using finance_backend.Application.Services.Income.Interfaces;
using finance_backend.Application.Services.User.Implementaitions;
using finance_backend.Application.Services.User.Interfaces;

namespace finance_backend.Infrastructure;

public static class ApplicationModule
{
    public static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        services
            .AddScoped<IUserService, UserService>()
            .AddScoped<ICategoryService, CategoryService>()
            .AddScoped<IBalanceService, BalanceService>()
            .AddScoped<IIncomeService, IncomeService>()
            .AddScoped<IExpenseService, ExpenseService>();

        return services;
    }
}