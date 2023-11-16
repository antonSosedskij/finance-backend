namespace finance_backend.Application.Services.Expense.Contracts;

public static class CreateExpense
{
    public sealed class Request
    {
        public string Title { get; set; }
        
        public decimal Amount { get; set; }
        public Guid BalanceId { get; set; }
    }

    public sealed class Response
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public decimal Amount { get; set; }
        public Guid BalanceId { get; set; }
    }
}