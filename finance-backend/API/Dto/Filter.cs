namespace finance_backend.API.Dto
{
    public interface IFilter
    {
        public IEnumerable<IFilterItem> Filters { get; set; }

        public interface IFilterItem
        {
            public string FieldName { get; set; }
            public object FieldValue { get; set; }
        }
    }

}
