namespace finance_backend.Application.Identity.Contracts
{
    /// <summary>
    /// �����, �������������� �������� ����� �� ������ ��������������.
    /// </summary>
    public class SignInSuccessResponse
    {
        /// <summary>
        /// �������� ��� ������ ����� �������������� (������������ ����).
        /// </summary>
        public required string Token { get; set; }

        /// <summary>
        /// �������� ��� ������ ��� ������������ (������������ ����).
        /// </summary>
        public required string Username { get; set; }

        /// <summary>
        /// �������� ��� ������ ������������� ������������ (������������ ����).
        /// </summary>
        public required Guid Id { get; set; }
    }
}
