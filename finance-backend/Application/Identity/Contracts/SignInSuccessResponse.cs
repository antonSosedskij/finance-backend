namespace finance_backend.Application.Identity.Contracts
{
    /// <summary>
    ///  ласс, представл€ющий успешный ответ на запрос аутентификации.
    /// </summary>
    public class SignInSuccessResponse
    {
        /// <summary>
        /// ѕолучает или задает токен аутентификации (об€зательное поле).
        /// </summary>
        public required string Token { get; set; }

        /// <summary>
        /// ѕолучает или задает им€ пользовател€ (об€зательное поле).
        /// </summary>
        public required string Username { get; set; }

        /// <summary>
        /// ѕолучает или задает идентификатор пользовател€ (об€зательное поле).
        /// </summary>
        public required Guid Id { get; set; }
    }
}
