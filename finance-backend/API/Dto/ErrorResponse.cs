using static System.Runtime.InteropServices.JavaScript.JSType;

namespace finance_backend.API.Dto
{
    /// <summary>
    /// Класс, представляющий формат ответа с ошибкой.
    /// </summary>
    public class ErrorResponse : IBaseResponse
    {
        /// <summary>
        /// Получает или задает значение, указывающее на успешность операции.
        /// </summary>
        public required bool IsSuccess { get; set; }

        /// <summary>
        /// Получает или задает коллекцию элементов ошибок.
        /// </summary>
        public IEnumerable<ErrorItem>? Errors { get; set; }

        /// <summary>
        /// Класс, представляющий элемент ошибки.
        /// </summary>
        public sealed class ErrorItem
        {
            /// <summary>
            /// Инициализирует новый экземпляр класса <see cref="ErrorItem"/> с указанным сообщением об ошибке.
            /// </summary>
            /// <param name="error">Сообщение об ошибке.</param>
            public ErrorItem(string error)
            {
                Error = error;
            }

            /// <summary>
            /// Получает или задает код ошибки.
            /// </summary>
            public string Error { get; set; }
        }
    }
}
