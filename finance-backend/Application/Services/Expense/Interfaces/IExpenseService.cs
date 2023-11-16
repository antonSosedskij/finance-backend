using finance_backend.Application.Services.Expense.Contracts;

namespace finance_backend.Application.Services.Expense.Interfaces;

public interface IExpenseService
{
    public Task<CreateExpense.Response> CreateExpense(CreateExpense.Request request);
}