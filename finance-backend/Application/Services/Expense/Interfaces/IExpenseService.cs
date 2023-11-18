using finance_backend.Application.Services.Expense.Contracts;

namespace finance_backend.Application.Services.Expense.Interfaces;

public interface IExpenseService
{
    public Task<CreateExpense.Response> CreateExpense(CreateExpense.Request request);

    public Task<GetExpense.Response> GetExpense(GetExpense.Request request);

    public Task<GetAllForUser.Response> GetAllForCurrentUser();
}