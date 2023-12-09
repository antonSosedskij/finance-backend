namespace finance_backend.API.Dto.Expense
{
    /// <summary>
    /// �����, �������������� ������ �� �������� �������.
    /// </summary>
    public class CreateExpenseRequest
    {
        /// <summary>
        /// �������� ��� ������ �������� �������.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// �������� ��� ������ ����� �������.
        /// </summary>
        public required decimal Amount { get; set; }

        /// <summary>
        /// �������� ��� ������ ������������� �������, � �������� ������������ ������.
        /// </summary>
        public required Guid BalanceId { get; set; }

        /// <summary>
        /// �������� ��� ������ ������������� ������������, ���������� � ��������.
        /// </summary>
        public required Guid UserId { get; set; }
    }
}
