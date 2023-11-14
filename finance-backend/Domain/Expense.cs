using finance_backend.Domain.Shared;

namespace finance_backend.DataAccess.Models;

public class Expense : MutableEntity<Guid>
{
    public string Title { get; set; }
    
    public Guid BalanceId { get; set; }
}