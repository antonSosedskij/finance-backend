namespace finance_backend.Application.Services.Category.Contracts;

public class CreateCategory
{
    public sealed class Request
    {
        public string Title { get; set; }
        
        public Guid UserId { get; set; }
    }
    
    public sealed class Response
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid UserId { get; set; } 
    }
}