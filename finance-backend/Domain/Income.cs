using finance_backend.Domain.Shared;

namespace finance_backend.Domain;

public class Income : MutableEntity<Guid>
{
    public string Title { get; set; }
    
    public decimal Amount { get; set; }
    
    public Guid OwnerId { get; set; }
    public virtual User Owner { get; set; }
    
    
}