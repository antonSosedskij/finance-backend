using finance_backend.Application.Repositories;
using finance_backend.DataAccess.Models;
using finance_backend.Domain;

namespace finance_backend.Infrastructure.Data_access.Repository;

public class ExpenseRepository : Repository<Expense, Guid>, IExpenseRepository
{
    public ExpenseRepository(ApplicationContext context) : base(context)
    {
        
    }
}