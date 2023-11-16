using finance_backend.DataAccess.Models;
using finance_backend.Domain.Shared;

namespace finance_backend.Domain;

public class Balance : MutableEntity<Guid>
{
    public string Title { get; set; } 
        
    public decimal Percent { get; set; }
    
    public virtual Category Category { get; set; }
    
    public Guid CategoryId { get; set; }
    
    public virtual IEnumerable<Expense> Expenses { get; set; }
}