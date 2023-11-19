namespace finance_backend.API.Dto
{
    public interface IItemsPagedDto<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
}