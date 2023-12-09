using finance_backend.Application.Identity.Contracts;
using finance_backend.Application.Repositories;
using finance_backend.Application.Services.Balance.Contracts;
using finance_backend.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace finance_backend.Infrastructure.Data_access.Repository;

public class BalanceRepository : Repository<Balance, Guid>, IBalanceRepository
{
    public BalanceRepository(ApplicationContext context) : base(context)
    {
     
    }

    public async Task<IEnumerable<Balance>> GetPagedBalancesByUserId(Guid userId, BalancePagedRequest request)
    {
        var userBalances = _context.balances.Where(e => e.User.Id == userId);
        var pagedBalances = userBalances.Skip((request.Page - 1) * request.Size).Take(request.Size);

        return await pagedBalances.ToListAsync();
    }

    public async Task<Balance> GetDefaultCommonBalance(Guid userId)
    {
        return await _context.balances
            .FirstOrDefaultAsync(b => b.UserId == userId && b.Title == "Общий");
    }

    public async Task<Balance> GetBalanceById(Guid balanceId)
    {
        return await _context.balances.FindAsync(balanceId);
    }

    public async Task Update(Balance balance)
    {
        // EntityState.Modified is used to inform EF that the entity should be updated in the database
        _context.Entry(balance).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<Balance> GetBalanceByTitleAndUserId(string title, Guid userId)
    {
        return await _context.balances
            .FirstOrDefaultAsync(b => b.Title == title && b.UserId == userId);
    }

    public async Task Delete(Guid balanceId)
    {
        var balance = await _context.balances.FindAsync(balanceId);

        if (balance != null)
        {
            _context.balances.Remove(balance);
            await _context.SaveChangesAsync();
        }
    }
}