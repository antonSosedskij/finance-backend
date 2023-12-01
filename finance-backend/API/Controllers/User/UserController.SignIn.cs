using finance_backend.API.Dto;
using finance_backend.Application.Identity.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.API.Controllers.User;

public partial class UserController : ControllerBase
{
    /// <summary>
    /// Аутентификация пользователя в системе.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /User/signin
    ///     {
    ///        "email": "string@gmail.com",
    ///        "password": "Qwerty123!"
    ///     }
    /// </remarks>
    /// <param name="request">Модель запроса для аутентификации: SignInRequest (содержит email и password)</param>
    /// <returns>Результат аутентификации пользователя.</returns>
    /// <response code="200">Вход в систему выполнен успешно.</response>
    /// <response code="400">Ошибка входа. Возвращается в случае неверных учетных данных или других проблем с аутентификацией.</response>
    [HttpPost("signin")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(SignInSuccessResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SignInSuccessResponse>> SignIn(SignInRequest request)
    {
        var response = await _identityService.SignIn(new SignInRequest
        {
            Email = request.Email,
            Password = request.Password,
        });

        if (response.IsSuccess)
        {
            return Ok(new SignInSuccessResponse
            {
                Token = response.Token,
                Id = response.Id,
                Username = response.Username,
            });
        }

        var errorItems = response.Errors.Select(error => new ErrorResponse.ErrorItem
        {
            Error = "Ошибка входа",
            Message = error
        });

        return BadRequest(new ErrorResponse
        {
            Errors = errorItems.ToList()
        });
    }

}