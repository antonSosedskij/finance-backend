using finance_backend.Application.Services.Income.Contracts;

namespace finance_backend.Application.Services.Income.Interfaces;

public interface IIncomeService
{
    public Task<CreateIncome.Response> CreateIncome(CreateIncomeRequest request);
    
    public Task<GetByUserId.Response> GetCurrentUserIncomes();
    
    public Task<GetUserIncomesSum.Response> GetUserIncomesSum();
    
}