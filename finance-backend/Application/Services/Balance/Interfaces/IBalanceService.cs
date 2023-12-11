using finance_backend.Application.Services.Balance.Contracts;

namespace finance_backend.Application.Services.Balance.Interfaces;

public interface IBalanceService
{
    Task<CreateBalanceResponse> CreateBalance(CreateBalanceRequest request);
    Task<GetBalanceResponse> GetBalance(Guid id);
    Task<PagedBalances> GetPagedBalancesForCurrentUser(BalancePagedRequest request);
    Task<DeleteBalanceResponse> DeleteBalance(Guid balanceId);
}