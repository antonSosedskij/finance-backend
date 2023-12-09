namespace finance_backend.API.Dto
{
    /// <summary>
    /// Класс, представляющий успешный ответ.
    /// </summary>
    public interface SuccessResponse<T>: IBaseResponse
    {
        /// <summary>
        /// Получает или задает дополнительное сообщение об успешной операции.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Получает или задает данные успешной операции.
        /// </summary>
        public T Data { get; set; }
    }
}
