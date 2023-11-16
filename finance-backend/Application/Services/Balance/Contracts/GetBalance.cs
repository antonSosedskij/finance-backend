namespace finance_backend.Application.Services.Balance.Contracts;

public static class GetBalance
{
    public sealed class Request
    {
        public Guid Id { get; set; }
    }
    
    public sealed class Response
    {
        public sealed class BalancesCategory
        {
            public Guid Id { get; set; }
            
            public string Title { get; set; }
        }
        
        public Guid Id { get; set; }
        
        public string Title { get; set; } 
        
        public decimal Percent { get; set; }
        
        public decimal AvailableAmount { get; set; }
        
        public decimal ExpensesSum { get; set; }
        public BalancesCategory Category { get; set; } 
    }
}