using finance_backend.API.Dto;
using finance_backend.Application.Identity.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.API.Controllers.User;

public partial class UserController : ControllerBase
{
    /// <summary>
    /// Регистрация нового пользователя.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /User/signup
    ///     {
    ///        "username": "string",
    ///        "email": "string@gmail.com",
    ///        "name": "string",
    ///        "lastname": "string",
    ///        "password": "Qwerty123!"
    ///     }
    /// </remarks>
    /// <param name="request">Модель запроса для регистрации: SignUpRequest.</param>
    /// <returns>Результат регистрации пользователя.</returns>
    /// <response code="201">Регистрация выполнена успешно.</response>
    /// <response code="400">Ошибка регистрации. Возвращается в случае неверных данных или других проблем при регистрации.</response>
    [HttpPost("signup")]
    [ProducesResponseType(typeof(SignInResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SignInResponse>> SignUp([FromBody] SignUpRequest request)
    {
        var signUpResponse = await _userService.SignUp(new SignUpRequest
        {
            Username = request.Username,
            Email = request.Email,
            Name = request.Name,
            Lastname = request.Lastname,
            Password = request.Password
        });

        if (signUpResponse.IsSuccess) {
            var signInRequest = new SignInRequest
            {
                Email = request.Email,
                Password = request.Password
            };
            var signInResponse = await _userService.SignIn(signInRequest);

            if (signInResponse.IsSuccess) {
                return Ok(signInResponse);
            }

            return BadRequest(signInResponse);
        }

        return BadRequest(signUpResponse);
    }
}