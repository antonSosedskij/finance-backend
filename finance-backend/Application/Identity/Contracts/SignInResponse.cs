using finance_backend.API.Dto;

namespace finance_backend.Application.Identity.Contracts
{
    /// <summary>
    /// �����, �������������� ����� �� ������ ��������������.
    /// </summary>
    public class SignInResponse : ErrorResponse, SuccessResponse<SignInSuccessResponse>
    {
        /// <summary>
        /// �������� ��� ������ ��������� �� �������� ��������������.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// �������� ��� ������ ������ �������� �������� ��������������.
        /// </summary>
        public SignInSuccessResponse? Data { get; set; }
    }
}
