using finance_backend.Application.Repositories;
using finance_backend.DataAccess.Models;
using finance_backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace finance_backend.Infrastructure.Data_access.Repository;

public class IncomeRepository : Repository<Income, Guid>, IIncomesRepository
{
    public IncomeRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Income>> GetIncomesByUserId(Guid userId)
    {
        var incomes = await _context.incomes.Where(i => i.Owner.Id == userId).ToListAsync();

        return incomes;
    }
}