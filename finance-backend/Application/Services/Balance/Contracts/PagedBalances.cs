using finance_backend.API.Dto;

namespace finance_backend.Application.Services.Balance.Contracts
{
    public class PagedBalances : IItemsPagedDto<BalanceView>
    {
        public IEnumerable<BalanceView> Items { get; set; }
        public int TotalCount { get; set; }
    }

}
