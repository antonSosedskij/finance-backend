namespace finance_backend.API.Dto.Expense
{
    /// <summary>
    /// Класс, представляющий запрос на создание расхода.
    /// </summary>
    public class CreateExpenseRequest
    {
        /// <summary>
        /// Получает или задает название расхода.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Получает или задает сумму расхода.
        /// </summary>
        public required decimal Amount { get; set; }

        /// <summary>
        /// Получает или задает идентификатор баланса, с которого производится расход.
        /// </summary>
        public required Guid BalanceId { get; set; }

        /// <summary>
        /// Получает или задает идентификатор пользователя, связанного с расходом.
        /// </summary>
        public required Guid UserId { get; set; }
    }
}
