using finance_backend.Domain.Shared;

namespace finance_backend.DataAccess.Models;

public class Income : MutableEntity<Guid>
{
    public string Title { get; set; } = "";
    
    public float Amount { get; set; }
    
}