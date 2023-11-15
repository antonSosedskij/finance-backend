using finance_backend.Application.Services.Income.Contracts;

namespace finance_backend.Application.Services.Income.Interfaces;

public interface IIncomeService
{
    public Task<CreateIncome.Response> CreateIncome(CreateIncome.Request request);
    public Task<GetByUserId.Response> GetCurrentUserIncomes();
}