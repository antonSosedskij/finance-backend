namespace finance_backend.Application.Services.Expense.Contracts;

public static class GetExpense
{
    public sealed class Request
    {
        public Guid Id { get; set; }
    }
    
    public sealed class Response
    {
        public sealed class ExpensesBalance
        {
            public Guid Id { get; set; }
            
            public string Title { get; set; } 
        
            public decimal Percent { get; set; }
            
            public Guid CategoryId { get; set; }
        }
        
        public Guid Id { get; set; }
        
        public string Title { get; set; }
    
        public decimal Amount { get; set; }
        
        public ExpensesBalance Balance { get; set;  }
    }
}