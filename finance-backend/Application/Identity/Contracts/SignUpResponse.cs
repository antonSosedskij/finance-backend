using finance_backend.API.Dto;

namespace finance_backend.Application.Identity.Contracts;

/// <summary>
/// �����, �������������� ����� �� ������ �����������.
/// </summary>
public class SignUpResponse : ErrorResponse, SuccessResponse<Guid>
{
    /// <summary>
    /// �������� ��� ������ �������������� ��������� �� �������� �������� �����������.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// �������� ��� ������ ������ �������� �������� �����������.
    /// </summary>
    public Guid Data { get; set; }
}
