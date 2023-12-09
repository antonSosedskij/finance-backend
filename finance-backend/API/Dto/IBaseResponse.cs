namespace finance_backend.API.Dto
{
    /// <summary>
    /// Интерфейс, представляющий базовый формат ответа.
    /// </summary>
    public interface IBaseResponse
    {
        /// <summary>
        /// Получает или задает значение, указывающее на успешность операции.
        /// </summary>
        bool IsSuccess { get; set; }
    }
}
