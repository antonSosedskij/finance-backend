using finance_backend.API.Dto;
using finance_backend.Application.Identity.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.API.Controllers.User;

public partial class UserController : ControllerBase
{
    /// <summary>
    /// �������������� ������������ � �������.
    /// </summary>
    /// <remarks>
    /// ������ �������:
    ///
    ///     POST /User/signin
    ///     {
    ///        "email": "string@gmail.com",
    ///        "password": "Qwerty123!"
    ///     }
    /// </remarks>
    /// <param name="request">������ ������� ��� ��������������: SignInRequest (�������� email � password)</param>
    /// <returns>��������� �������������� ������������.</returns>
    /// <response code="200">���� � ������� �������� �������.</response>
    /// <response code="400">������ �����. ������������ � ������ �������� ������� ������ ��� ������ ������� � ���������������.</response>
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
            Error = "������ �����",
            Message = error
        });

        return BadRequest(new ErrorResponse
        {
            Errors = errorItems.ToList()
        });
    }

}