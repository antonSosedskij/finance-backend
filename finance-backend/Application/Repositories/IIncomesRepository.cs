using finance_backend.DataAccess.Models;
using finance_backend.Domain;

namespace finance_backend.Application.Repositories;

public interface IIncomesRepository : IRepository<Income, Guid>
{
    public Task<IEnumerable<Income>> GetIncomesByUserId(Guid id);
}