using finance_backend.API.Dto;
using finance_backend.Application.Identity.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.API.Controllers.User;

public partial class UserController : ControllerBase
{   
    [HttpPost("login")]
    public async Task<ActionResult<CreateToken.SuccessAuthResponse>> Login(UserLoginRequest request)
    {
        var token = await _identityService.CreateToken(new CreateToken.Request
        {
            Email = request.email,
            Password = request.password
        });


        return Ok(token);
    }
}