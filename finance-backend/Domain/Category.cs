using finance_backend.DataAccess.Models;
using finance_backend.Domain.Shared;

namespace finance_backend.Domain;

public class Category : MutableEntity<Guid>
{
    public string Title { get; set; }
    
    public Guid UserId { get; set; }

    public virtual User User { get; set; }
    
    public virtual ICollection<Balance> Balances { get; set; }
}