namespace finance_backend.API.Dto.Category
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
