namespace finance_backend.Application.Services.Balance.Contracts
{
    public class UpdateBalanceRequest
    {
        public Guid BalanceId { get; set; }
        public string Title { get; set; }
        public decimal Percent { get; set; }
    }
}
