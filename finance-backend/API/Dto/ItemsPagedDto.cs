namespace finance_backend.API.Dto
{
    /// <summary>
    /// Интерфейс для представления страницы элементов с информацией о количестве.
    /// </summary>
    /// <typeparam name="T">Тип элементов.</typeparam>
    public interface IItemsPagedDto<T>
    {
        /// <summary>
        /// Получает или задает коллекцию элементов.
        /// </summary>
        IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Получает или задает общее количество элементов.
        /// </summary>
        int TotalCount { get; set; }
    }
}
