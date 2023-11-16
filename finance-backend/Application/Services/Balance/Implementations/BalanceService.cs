using System.Security.Principal;
using finance_backend.Application.Identity.Interfaces;
using finance_backend.Application.Repositories;
using finance_backend.Application.Services.Balance.Contracts;
using finance_backend.Application.Services.Balance.Interfaces;
using finance_backend.Application.Services.Income.Interfaces;

namespace finance_backend.Application.Services.Balance.Implementations;

public class BalanceService : IBalanceService
{
    private readonly IBalanceRepository _balanceRepository;
    private readonly IIncomeService _incomeService;
    private readonly IIdentityService _identityService;
    
    public BalanceService(
        IBalanceRepository balanceRepository,
        IIncomeService incomeService,
        IIdentityService identityService)
    {
        _balanceRepository = balanceRepository;
        _incomeService = incomeService;
        _identityService = identityService;
    }
    
    public async Task<CreateBalance.Response> CreateBalance(CreateBalance.Request request)
    {
        var currentUserId = await _identityService.GetCurrentUserId();
        
        var balance = new Domain.Balance
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Percent = request.Percent,
            CategoryId = request.CategoryId,
            CreatedDate = DateTime.UtcNow,
        };

        await _balanceRepository.Save(balance);
        
        return new CreateBalance.Response
        {
            Id = balance.Id,
            Title = balance.Title,
            Percent = balance.Percent,
            CategoryId = balance.CategoryId
        };
    }

    public async Task<GetBalance.Response> GetBalance(GetBalance.Request request)
    {
        var balance = await _balanceRepository.FindById(request.Id);
        
        var userIncomes = await _incomeService.GetUserIncomesSum();
        var availableAmount = (balance.Percent * userIncomes.IncomesSum) / 100;
        var expensesSum = balance.Expenses.Sum(i => i.Amount);

        return new GetBalance.Response
        {
            Id = balance.Id,
            Title = balance.Title,
            Percent = balance.Percent,
            AvailableAmount = availableAmount,
            ExpensesSum = expensesSum,
            Category = new GetBalance.Response.BalancesCategory
            {
                Id = balance.Category.Id,
                
                Title = balance.Category.Title
            }
        };
    }
}