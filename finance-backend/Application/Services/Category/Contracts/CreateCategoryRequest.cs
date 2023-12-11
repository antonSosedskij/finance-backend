namespace finance_backend.Application.Services.Category.Contracts
{
    /// <summary>
    ///  ласс, представл€ющий запрос на создание категории.
    /// </summary>
    public class CreateCategoryRequest
    {
        /// <summary>
        /// ѕолучает или задает название категории.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// ѕолучает или задает идентификатор пользовател€, св€занного с категорией.
        /// </summary>
        public required Guid UserId { get; set; }
    }
}
