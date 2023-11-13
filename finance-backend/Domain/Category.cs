using finance_backend.Domain.Shared;

namespace finance_backend.Domain;

public class Category : MutableEntity<Guid>
{
    public string Title { get; set; }
    
    public Guid UserId { get; set; }

    public User User { get; set; }
}