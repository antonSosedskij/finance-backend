using finance_backend.Application.Services.Balance.Contracts;
using finance_backend.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace finance_backend.Application.Repositories;

public interface IBalanceRepository : IRepository<Balance, Guid>
{
    public Task<IEnumerable<Balance>> GetPagedBalancesByUserId(Guid userId, BalancePagedRequest request);
    public Task<Balance> GetDefaultCommonBalance(Guid userId);
    public Task<Balance> GetBalanceById(Guid balanceId);
    public Task Update(Balance balance);
    public Task<Balance> GetBalanceByTitleAndUserId(string title, Guid userId);
    public Task Delete(Guid balanceId);
}