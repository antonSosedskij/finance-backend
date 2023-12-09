namespace finance_backend.Application.Services.Balance.Contracts
{
    /// <summary>
    /// Класс, представляющий запрос на создание баланса.
    /// </summary>
    public class CreateBalanceRequest
    {
        /// <summary>
        /// Получает или задает название баланса (обязательное поле).
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Получает или задает процент баланса (обязательное поле).
        /// </summary>
        public required decimal Percent { get; set; }

        /// <summary>
        /// Получает или задает идентификатор категории, связанной с балансом (обязательное поле).
        /// </summary>
        public required Guid CategoryId { get; set; }
    }
}
