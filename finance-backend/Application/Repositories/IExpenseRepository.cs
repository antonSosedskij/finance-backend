using finance_backend.DataAccess.Models;
using finance_backend.Domain;

namespace finance_backend.Application.Repositories;

public interface IExpenseRepository : IRepository<Expense, Guid>
{
    
}