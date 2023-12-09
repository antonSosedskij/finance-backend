namespace finance_backend.API.Dto.Income
{
    /// <summary>
    /// �����, �������������� ������ �� �������� ������.
    /// </summary>
    public class CreateIncomeRequest
    {
        /// <summary>
        /// �������� ��� ������ �������� ������.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// �������� ��� ������ ����� ������.
        /// </summary>
        public required decimal Amount { get; set; }
    }
}
