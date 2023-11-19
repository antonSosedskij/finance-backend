using finance_backend.API.Dto;
using finance_backend.Application.Repositories;
using finance_backend.Application.Services.Expense.Contracts;
using finance_backend.DataAccess.Models;
using finance_backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace finance_backend.Infrastructure.Data_access.Repository;

public class ExpenseRepository : Repository<Expense, Guid>, IExpenseRepository
{
    public ExpenseRepository(ApplicationContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<Expense>> GetAllExpensesByUserId(Guid userId)
    {
        var userExpenses = await _context.expenses.Where(e => e.User.Id == userId).ToListAsync();

        return userExpenses;
    }

    public async Task<IEnumerable<Expense>> GetPagedExpensesByUserId(Guid userId, ExpensesRequest request)
    {
        var userExpenses = _context.expenses.Where(e => e.User.Id == userId);

        var ex = userExpenses.ToList();

        var pagedExpenses = userExpenses.Skip((request.Page - 1) * request.Size).Take(request.Size);

        var p = pagedExpenses.ToList();

        return await pagedExpenses.ToListAsync();
    }
}