namespace finance_backend.Application.Services.Category.Contracts;

public static class GetCategories
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
        }

        public IEnumerable<Item> Categories { get; set; }
    }
}