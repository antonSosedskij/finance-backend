using finance_backend.Application.Identity.Interfaces;
using finance_backend.Application.Repositories;
using finance_backend.Application.Services.Income.Contracts;
using finance_backend.Application.Services.Income.Interfaces;

namespace finance_backend.Application.Services.Income.Implementations;

public class IncomeService : IIncomeService
{
    private readonly IIncomesRepository _incomesRepository;
    private readonly IIdentityService _identityService;

    public IncomeService(
        IIncomesRepository incomesRepository,
        IIdentityService identityService)
    {
        _incomesRepository = incomesRepository;
        _identityService = identityService;
    }

    public async Task<CreateIncome.Response> CreateIncome(CreateIncome.Request request)
    {
        var currentUserId = await _identityService.GetCurrentUserId();

        var income = new Domain.Income
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Amount = request.Amount,
            OwnerId = currentUserId
        };

        await _incomesRepository.Save(income);

        return new CreateIncome.Response
        {
            Id = income.Id,
            Title = income.Title,
            Amount = income.Amount,
            UserId = income.OwnerId
        };
    }

    public async Task<GetByUserId.Response> GetCurrentUserIncomes()
    {
        var userId = await _identityService.GetCurrentUserId();
        
        var incomes = await _incomesRepository.GetIncomesByUserId(userId);

        return new GetByUserId.Response
        {
            Incomes = incomes.Select(i => new GetByUserId.Response.Item
            {
                UserId = i.Owner.Id,
                Title = i.Title,
                Amount = i.Amount
            })
        };
    }

    public async Task<GetUserIncomesSum.Response> GetUserIncomesSum()
    {
        var userId = await _identityService.GetCurrentUserId();
        
        var incomes = await _incomesRepository.GetIncomesByUserId(userId);

        return new GetUserIncomesSum.Response
        {
            UserId = userId,
            IncomesSum = incomes.Sum(i => i.Amount)
        };
    }
    //переписать под текущего юзера
    
    
}