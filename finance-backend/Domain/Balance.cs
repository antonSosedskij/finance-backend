using finance_backend.Domain.Shared;

namespace finance_backend.DataAccess.Models;

public class Balance : MutableEntity<Guid>
{
    public float Percent { get; set; }
    
    public Guid CategoryId { get; set; }
}