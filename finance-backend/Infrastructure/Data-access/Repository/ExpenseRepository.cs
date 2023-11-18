using finance_backend.Application.Repositories;
using finance_backend.DataAccess.Models;
using finance_backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace finance_backend.Infrastructure.Data_access.Repository;

public class ExpenseRepository : Repository<Expense, Guid>, IExpenseRepository
{
    public ExpenseRepository(ApplicationContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<Expense>> GetExpensesByUserId(Guid userId)
    {
        var expenses = await _context.expenses.Where(e => e.User.Id == userId).ToListAsync();

        return expenses;
    }
}