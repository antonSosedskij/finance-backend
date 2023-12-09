using finance_backend.API.Dto;

namespace finance_backend.Application.Identity.Contracts
{
    /// <summary>
    /// Класс, представляющий ответ на запрос аутентификации.
    /// </summary>
    public class SignInResponse : ErrorResponse, SuccessResponse<SignInSuccessResponse>
    {
        /// <summary>
        /// Получает или задает сообщение об операции аутентификации.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Получает или задает данные успешной операции аутентификации.
        /// </summary>
        public SignInSuccessResponse? Data { get; set; }
    }
}
