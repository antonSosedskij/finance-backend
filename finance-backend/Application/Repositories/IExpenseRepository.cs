using finance_backend.Application.Services.Expense.Contracts;
using finance_backend.Domain;

namespace finance_backend.Application.Repositories;

public interface IExpenseRepository : IRepository<Expense, Guid>
{
    public Task<IEnumerable<Expense>> GetAllExpensesByUserId(Guid userId);
    public Task<IEnumerable<Expense>> GetPagedExpensesByUserId(Guid userId, ExpensesRequest request);
}