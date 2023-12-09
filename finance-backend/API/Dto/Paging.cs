namespace finance_backend.API.Dto
{
    /// <summary>
    /// Интерфейс для представления параметров пагинации.
    /// </summary>
    public interface IPaging
    {
        /// <summary>
        /// Получает или задает номер страницы.
        /// </summary>
        int Page { get; set; }

        /// <summary>
        /// Получает или задает размер страницы.
        /// </summary>
        int Size { get; set; }
    }
}
