using finance_backend.Application.Repositories;
using finance_backend.Application.Services.Balance.Interfaces;
using finance_backend.Domain;

namespace finance_backend.Infrastructure.Data_access.Repository;

public class BalanceRepository : Repository<Balance, Guid>, IBalanceRepository
{
    public BalanceRepository(ApplicationContext context) : base(context)
    {
        
    }
}