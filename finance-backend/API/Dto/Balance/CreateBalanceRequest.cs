namespace finance_backend.API.Dto.Balance;

public class CreateBalanceRequest
{
    public string Title { get; set; }
        
    public decimal Percent { get; set; }
        
    public Guid CategoryId { get; set; }
}