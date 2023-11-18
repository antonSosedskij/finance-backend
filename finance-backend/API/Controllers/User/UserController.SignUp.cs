using finance_backend.Application.Identity.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace finance_backend.API.Controllers.User;

public partial class UserController : ControllerBase
{
    [HttpPost("signup")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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