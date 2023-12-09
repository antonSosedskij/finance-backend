namespace finance_backend.API.Dto
{
    /// <summary>
    /// Интерфейс для представления набора фильтров.
    /// </summary>
    public interface IFilter
    {
        /// <summary>
        /// Получает или задает коллекцию элементов фильтрации.
        /// </summary>
        IEnumerable<IFilterItem> Filters { get; set; }
    }
}
