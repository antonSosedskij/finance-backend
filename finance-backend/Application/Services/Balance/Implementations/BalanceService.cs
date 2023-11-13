using finance_backend.Application.Repositories;
using finance_backend.Application.Services.Balance.Contracts;
using finance_backend.Application.Services.Balance.Interfaces;

namespace finance_backend.Application.Services.Balance.Implementations;

public class BalanceService : IBalanceService
{
    private readonly IBalanceRepository _balanceRepository;

    public BalanceService(
        IBalanceRepository balanceRepository)
    {
        _balanceRepository = balanceRepository;
    }
    
    public async Task<CreateBalance.Response> CreateBalance(CreateBalance.Request request)
    {
        var balance = new Domain.Balance
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Percent = request.Percent,
            CategoryId = request.CategoryId,
            CreatedDate = DateTime.UtcNow
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
}