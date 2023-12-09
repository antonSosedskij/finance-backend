using finance_backend.API.Dto;

namespace finance_backend.Application.Identity.Contracts;

/// <summary>
/// Класс, представляющий ответ на запрос регистрации.
/// </summary>
public class SignUpResponse : ErrorResponse, SuccessResponse<Guid>
{
    /// <summary>
    /// Получает или задает дополнительное сообщение об успешной операции регистрации.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Получает или задает данные успешной операции регистрации.
    /// </summary>
    public Guid Data { get; set; }
}
