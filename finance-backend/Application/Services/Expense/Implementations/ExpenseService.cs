using finance_backend.Application.Identity.Interfaces;
using finance_backend.Application.Repositories;
using finance_backend.Application.Services.Category.Contracts;
using finance_backend.Application.Services.Expense.Contracts;
using finance_backend.Application.Services.Expense.Interfaces;

namespace finance_backend.Application.Services.Expense.Implementations;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _expenseRepository;
    private readonly IIdentityService _identityService;

    public ExpenseService(
        IExpenseRepository expenseRepository,
        IIdentityService identityService)
    {
        _expenseRepository = expenseRepository;
        _identityService = identityService;
    }
    
    public async Task<CreateExpense.Response> CreateExpense(CreateExpense.Request request)
    {
        var currentUserId = await _identityService.GetCurrentUserId();

        var expense = new Domain.Expense
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Amount = request.Amount,
            UserId = currentUserId,
            BalanceId = request.BalanceId
        };

        await _expenseRepository.Save(expense);

        return new CreateExpense.Response
        {
            Id = expense.Id,
            Title = expense.Title,
            Amount = expense.Amount,
            UserId = expense.UserId,
            BalanceId = expense.BalanceId
        };
    }

    public async Task<GetExpense.Response> GetExpense(GetExpense.Request request)
    {
        var expense = await _expenseRepository.FindById(request.Id);

        return new GetExpense.Response
        {
            Title = expense.Title,
            Amount = expense.Amount,
            User = new GetExpense.Response.UserResponse  {
                Id = expense.User.Id,
                Username = expense.User.Username,
                Email = expense.User.Email,
                Name = expense.User.Name,
                Lastname = expense.User.Lastname,
            },
            Balance = new GetExpense.Response.ExpensesBalance
            {
                Id = expense.Balance.Id,
                Title = expense.Balance.Title,
                Percent = expense.Balance.Percent,
                CategoryId = expense.Balance.CategoryId
            }
        };
    }

    public async Task<GetAllForUser.Response> GetAllForCurrentUser()
    {
        var userId = await _identityService.GetCurrentUserId();

        var expenses = await _expenseRepository.GetExpensesByUserId(userId);

        return new GetAllForUser.Response
        {
            Expenses = expenses.Select(e => new GetAllForUser.Response.ExpenseResponse
            {
                Id = e.Id,
                Title = e.Title,
                Amount = e.Amount,
            })
        };
    }
}