using finance_backend.API.Dto;
using finance_backend.Application.Identity.Interfaces;
using finance_backend.Application.Services.User.Contracts;
using finance_backend.Application.Services.User.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.API.Controllers.User;

[ApiController]
[Route("api/[controller]")]
public partial class UserController : ControllerBase
{

    private readonly IIdentityService _identityService;
    private readonly IUserService _userService;

    public UserController(IUserService userService, IIdentityService identityService, IConfiguration configuration)
    {
        _userService = userService;
        _identityService = identityService;
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequest registerRequest)
    {
        var registration = await _userService.Register(new Register.Request
        {
            Username = registerRequest.Username,
            Email = registerRequest.Email,
            Name = registerRequest.Name,
            Lastname = registerRequest.Lastname,
            Password = registerRequest.Password
        });
        
        return Created($"api/v1/users/{registration.Id}", registration.Id);
    }
}