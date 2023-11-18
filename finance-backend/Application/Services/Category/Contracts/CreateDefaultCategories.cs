namespace finance_backend.Application.Services.Balance.Contracts;

public class CreateDefaultCategories
{
    public sealed class Request
    {
        
    }
    
    public sealed class Response
    {
        public sealed class Item
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public Guid UserId { get; set; }
        }
        
        public IEnumerable<Item> Categories { get; set; }
    }
}