namespace finance_backend.Application.Services.Balance.Contracts
{
    /// <summary>
    /// Модель представления баланса.
    /// </summary>
    public class BalanceView
    {
        /// <summary>
        /// Идентификатор баланса.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Название баланса.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Категория баланса.
        /// </summary>
        public required string CategoryName { get; set; }

        /// <summary>
        /// Процент баланса.
        /// </summary>
        public required decimal Percent { get; set; }

        /// <summary>
        /// Доступная сумма на балансе.
        /// </summary>
        public decimal AvailableAmount { get; set; }

        /// <summary>
        /// Сумма расходов на балансе.
        /// </summary>
        public decimal ExpensesSum { get; set; }
    }
}
