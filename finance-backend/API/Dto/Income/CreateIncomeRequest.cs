namespace finance_backend.API.Dto.Income;

public class CreateIncomeRequest
{
    public string Title { get; set; }
    
    public decimal Amount { get; set; }
}