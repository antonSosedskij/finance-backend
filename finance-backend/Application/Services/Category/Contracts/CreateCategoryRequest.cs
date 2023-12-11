namespace finance_backend.Application.Services.Category.Contracts
{
    /// <summary>
    /// �����, �������������� ������ �� �������� ���������.
    /// </summary>
    public class CreateCategoryRequest
    {
        /// <summary>
        /// �������� ��� ������ �������� ���������.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// �������� ��� ������ ������������� ������������, ���������� � ����������.
        /// </summary>
        public required Guid UserId { get; set; }
    }
}
