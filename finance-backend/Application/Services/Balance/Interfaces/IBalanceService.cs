using finance_backend.Application.Services.Balance.Contracts;

namespace finance_backend.Application.Services.Balance.Interfaces;

public interface IBalanceService
{
    Task<CreateBalance.Response> CreateBalance(CreateBalance.Request request);
}