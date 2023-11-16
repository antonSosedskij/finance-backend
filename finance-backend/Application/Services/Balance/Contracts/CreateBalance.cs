namespace finance_backend.Application.Services.Balance.Contracts;

public class CreateBalance
{
    public sealed class Request
    {
        public string Title { get; set; }
        
        public decimal Percent { get; set; }
        
        public Guid CategoryId { get; set; }
    }

    public sealed class Response
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        public decimal Percent { get; set; }
        
        public Guid CategoryId { get; set; }
        
    }
}