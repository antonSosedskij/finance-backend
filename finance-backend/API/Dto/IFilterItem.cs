namespace finance_backend.API.Dto
{
    /// <summary>
    /// Интерфейс для представления элемента фильтрации.
    /// </summary>
    public interface IFilterItem
    {
        /// <summary>
        /// Получает или задает имя поля фильтрации.
        /// </summary>
        string FieldName { get; set; }

        /// <summary>
        /// Получает или задает значение поля фильтрации.
        /// </summary>
        object FieldValue { get; set; }
    }
}
