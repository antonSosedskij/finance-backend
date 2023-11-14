using finance_backend.Domain.Shared;

namespace finance_backend.Domain;

public class Balance : MutableEntity<Guid>
{
    public string Title { get; set; } 
        
    public decimal Percent { get; set; }
    
    //категория, к которой принадлежит баланс
    public virtual Category Category { get; set; }
    
    public Guid CategoryId { get; set; }
}