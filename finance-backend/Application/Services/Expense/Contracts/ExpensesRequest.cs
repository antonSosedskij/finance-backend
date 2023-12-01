using finance_backend.API.Dto;

namespace finance_backend.Application.Services.Expense.Contracts
{
    public class ExpensesRequest : IPaging
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
