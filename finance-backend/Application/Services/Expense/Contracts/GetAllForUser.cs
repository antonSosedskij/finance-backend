using finance_backend.API.Dto;
using static finance_backend.Application.Services.Expense.Contracts.PagedExpenses;

namespace finance_backend.Application.Services.Expense.Contracts;

public class PagedExpenses: IItemsPagedDto<ExpenseResponse>
{
    public IEnumerable<ExpenseResponse> Items { get; set; }
    public int TotalCount { get; set; }

    public sealed class ExpenseResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
    }
}
