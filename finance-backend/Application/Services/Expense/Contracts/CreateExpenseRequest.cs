namespace finance_backend.Application.Services.Expense.Contracts
{
    /// <summary>
    /// Модель запроса для создания расхода.
    /// </summary>
    public class CreateExpenseRequest
    {
        /// <summary>
        /// Получает или задает название расхода.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Получает или задает сумму расхода.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Получает или задает идентификатор баланса, к которому относится расход.
        /// </summary>
        public Guid BalanceId { get; set; }
    }
}
