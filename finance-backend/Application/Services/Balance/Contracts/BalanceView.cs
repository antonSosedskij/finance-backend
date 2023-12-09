namespace finance_backend.Application.Services.Balance.Contracts
{
    public class BalanceView
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Percent { get; set; }
        public string CategoryName { get; set; }
        public Guid UserId { get; set; }
    }
}
