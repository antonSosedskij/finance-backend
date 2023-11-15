namespace finance_backend.Application.Services.Income.Contracts;

public static class GetByUserId
{
    public sealed class Request
    {
        
    }

    public sealed class Response
    {
        public sealed class Item
        {
            public string Title { get; set; }
            public decimal Amount { get; set; }
            public Guid UserId { get; set; }
        }

        public IEnumerable<Item> Incomes { get; set; }
    }
}