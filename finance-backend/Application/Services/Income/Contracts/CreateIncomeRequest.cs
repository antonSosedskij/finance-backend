namespace finance_backend.Application.Services.Income.Contracts
{
    /// <summary>
    /// Класс, представляющий запрос на создание дохода.
    /// </summary>
    public class CreateIncomeRequest
    {
        /// <summary>
        /// Получает или задает название дохода.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Получает или задает сумму дохода.
        /// </summary>
        public required decimal Amount { get; set; }
    }
}
