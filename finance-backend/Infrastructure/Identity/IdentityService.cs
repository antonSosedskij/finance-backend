using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using finance_backend.Application.Identity.Contracts;
using finance_backend.Application.Identity.Interfaces;
using finance_backend.Application.Repositories;
using finance_backend.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace finance_backend.DataAccess.Models.Identity;

public class IdentityService : IIdentityService
{

    private readonly UserManager<IdentityUser<Guid>> _userManager;
    private readonly SignInManager<IdentityUser<Guid>> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly IRepository<Domain.User, Guid> _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public IdentityService( 
        UserManager<IdentityUser<Guid>> userManager,
        SignInManager<IdentityUser<Guid>> signInManager,
        IConfiguration configuration,
        IRepository<Domain.User, Guid> repository,
        IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _userRepository = repository;
        _httpContextAccessor = httpContextAccessor;
    }


    public Task<Guid> GetCurrentUserId()
    {
        var claimsPrincipal = _httpContextAccessor.HttpContext?.User;
        return Task.FromResult(Guid.Parse(_userManager.GetUserId(claimsPrincipal)));
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

    public async Task<CreateToken.SuccessAuthResponse> CreateToken(CreateToken.Request request)
    {
        var userByEmail = await _userManager.FindByEmailAsync(request.Email);
        IdentityUser<Guid> identityUser;

        if (userByEmail == null)
        {
            throw new Exception("Пользователь не найден");
        }
        else
        {
            identityUser = userByEmail;
        }

        var signInResult = await _signInManager.PasswordSignInAsync(identityUser, request.Password, true, false);

        if (!signInResult.Succeeded)
        {
            throw new Exception("Неправильный логин или пароль");
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, identityUser.Email),
            new Claim(ClaimTypes.NameIdentifier, identityUser.Id.ToString())
        };

        var token = new JwtSecurityToken
        (
            claims: claims,
            expires: DateTime.UtcNow.AddHours(5),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"])),
                SecurityAlgorithms.HmacSha256
            )
        );

        var domainUser = await _userRepository.FindById(identityUser.Id);

        return new CreateToken.SuccessAuthResponse
        {
            Token =  new JwtSecurityTokenHandler().WriteToken(token),
            Username = domainUser.Username,
            Id = domainUser.Id
        };
    }
}