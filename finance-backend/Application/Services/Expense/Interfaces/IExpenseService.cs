using finance_backend.Application.Services.Expense.Contracts;

namespace finance_backend.Application.Services.Expense.Interfaces;

public interface IExpenseService
{
    public Task<CreateExpense.Response> CreateExpense(CreateExpenseRequest request);

    public Task<GetExpense.Response> GetById(Guid id);

    public Task<PagedExpenses> GetPagedExpensesForCurrentUser(ExpensesRequest request);
}