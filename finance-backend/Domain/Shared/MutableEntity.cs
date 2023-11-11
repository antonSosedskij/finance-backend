namespace finance_backend.Domain.Shared
{
    /// <summary>
    /// Базовый класс для изменяющихся сущностей
    /// </summary>
    public abstract class MutableEntity<TId> : BaseEntity<TId>
    {
        /// <summary>
        /// Дата обновления сущности, по умолчанию - null
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Дата удаления сущности, по умолчанию - null
        /// </summary>
        public DateTime? RemovedDate { get; set; }
    }
}
