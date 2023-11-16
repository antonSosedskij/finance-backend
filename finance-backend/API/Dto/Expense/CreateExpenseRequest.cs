namespace finance_backend.API.Dto.Expense;

public class CreateExpenseRequest
{
    public string Title { get; set; }
    public decimal Amount { get; set; }
    public Guid BalanceId { get; set; }
}