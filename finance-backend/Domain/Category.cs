using finance_backend.Domain.Shared;

namespace finance_backend.DataAccess.Models;

public class Category : BaseEntity<Guid>
{
    public string Title { get; set; }
    
    public Guid UserId { get; set; }
}