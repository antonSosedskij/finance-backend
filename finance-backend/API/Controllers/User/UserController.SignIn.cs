using finance_backend.API.Dto;
using finance_backend.Application.Identity.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.API.Controllers.User;

public partial class UserController : ControllerBase
{   
    [HttpPost("signin")]
    public async Task<ActionResult<SignInResponse>> SignIn(UserLoginRequest request)
    {
        var token = await _identityService.SignIn(new SignInRequest
        {
            Email = request.email,
            Password = request.password
        });

        return Ok(token);
    }
}