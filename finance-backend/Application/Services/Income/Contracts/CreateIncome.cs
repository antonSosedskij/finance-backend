namespace finance_backend.Application.Services.Income.Contracts;

public class CreateIncome
{
    public sealed class Request
    {
        public string Title { get; set; }
        public decimal Amount { get; set; }
    }
    
    public sealed class Response
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public Guid UserId { get; set; }
    }
}