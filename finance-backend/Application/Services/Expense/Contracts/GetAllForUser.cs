namespace finance_backend.Application.Services.Expense.Contracts;

public static class GetAllForUser
{
    public sealed class Request
    {

    }

    public sealed class Response
    {
        public sealed class ExpenseResponse
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public decimal Amount { get; set; }
        }

        public IEnumerable<ExpenseResponse> Expenses { get; set; }
    }
}