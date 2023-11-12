using finance_backend.Application.Identity.Contracts;
using finance_backend.Application.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace finance_backend.DataAccess.Models.Identity;

public class IdentityService : IIdentityService
{

    private readonly UserManager<IdentityUser<Guid>> _userManager;

    public IdentityService( 
        UserManager<IdentityUser<Guid>> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<CreateUser.Response> CreateUser(CreateUser.Request request)
    {
        var existedUser = await _userManager.FindByEmailAsync(request.Email);

        if (existedUser != null)
        {
            
        }

        var newUser = new IdentityUser<Guid>
        {
            UserName = request.Username,
            Email = request.Email
        };

        var identityResult = await _userManager.CreateAsync(newUser, request.Password);

        if (identityResult.Succeeded)
        {
            return new CreateUser.Response
            {
                IsSuccess = true,
                Id = newUser.Id
            };
        }

        return new CreateUser.Response
        {
            IsSuccess = false,
            Errors = identityResult.Errors.Select(x => x.Description).ToArray(),
        };
    }
}