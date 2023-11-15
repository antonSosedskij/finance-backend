using finance_backend.Domain.Shared;

namespace finance_backend.Domain;

public class Balance : MutableEntity<Guid>
{
    public string Title { get; set; } 
        
    public decimal Percent { get; set; }
    
    public virtual User User { get; set; }

    public Guid UserId { get; set; }
    //категория, к которой принадлежит баланс
    public virtual Category Category { get; set; }
    
    public Guid CategoryId { get; set; }
}