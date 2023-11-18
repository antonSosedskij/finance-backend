using finance_backend.Application.Repositories;
using finance_backend.Application.Services.Expense.Contracts;
using finance_backend.Application.Services.Expense.Interfaces;

namespace finance_backend.Application.Services.Expense.Implementations;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _expenseRepository;

    public ExpenseService(
        IExpenseRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
    }
    
    public async Task<CreateExpense.Response> CreateExpense(CreateExpense.Request request)
    {
        var expense = new Domain.Expense
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Amount  = request.Amount,
            BalanceId = request.BalanceId
        };

        await _expenseRepository.Save(expense);

        return new CreateExpense.Response
        {
            Id = expense.Id,
            Title = expense.Title,
            Amount = expense.Amount,
            BalanceId = expense.BalanceId
        };
    }

    public async Task<GetExpense.Response> GetExpense(GetExpense.Request request)
    {
        var expense = await _expenseRepository.FindById(request.Id);

        return new GetExpense.Response
        {
            Id = expense.Id,
            Title = expense.Title,
            Amount = expense.Amount,
            Balance = new GetExpense.Response.ExpensesBalance
            {
                Id = expense.Balance.Id,
                Title = expense.Balance.Title,
                Percent = expense.Balance.Percent,
                CategoryId = expense.Balance.CategoryId
            }
        };
    }
}