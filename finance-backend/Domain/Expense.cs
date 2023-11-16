using finance_backend.Domain.Shared;

namespace finance_backend.Domain;

public class Expense : MutableEntity<Guid>
{
    public string Title { get; set; }
    
    public decimal Amount { get; set; }
    public Guid BalanceId { get; set; }
    
    public virtual Balance Balance { get; set;  }
}