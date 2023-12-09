using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using finance_backend.API.Dto;
using finance_backend.Application.Identity.Contracts;
using finance_backend.Application.Identity.Interfaces;
using finance_backend.Application.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static finance_backend.API.Dto.ErrorResponse;

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

    public async Task<SignUpResponse> SignUp(SignUpRequest request)
    {
        var existedUser = await _userManager.FindByEmailAsync(request.Email);

        if (existedUser != null)
        {
            var errorItem = new ErrorItem("Пользователь с таким email уже есть в системе.");
            return new SignUpResponse
            {
                IsSuccess = false,
                Errors = new List<ErrorItem> { errorItem },
            };
        }

        var newUser = new IdentityUser<Guid>
        {
            UserName = request.Username,
            Email = request.Email
        };

        var identityResult = await _userManager.CreateAsync(newUser, request.Password);

        if (identityResult.Succeeded)
        {
            return new SignUpResponse
            {
                IsSuccess = true,
                Data = newUser.Id
            };
        }

        return new SignUpResponse
        {
            IsSuccess = false,
            Errors = identityResult.Errors.Select(x => new ErrorItem(x.Description)).ToArray()
        };

    }

    public async Task<SignInResponse> SignIn(SignInRequest request)
    {
        var userByEmail = await _userManager.FindByEmailAsync(request.Email);
        IdentityUser<Guid> identityUser;

        if (userByEmail == null)
        {
            var error = new ErrorItem("Пользователь с таким email уже есть в системе.");
            return new SignInResponse
            {
                IsSuccess = false,
                Errors = new[] { error }
            };
        }
        else
        {
            identityUser = userByEmail;
        }

        var signInResult = await _signInManager.PasswordSignInAsync(identityUser, request.Password, true, false);

        if (!signInResult.Succeeded)
        {
            var error = new ErrorItem("Вы ввели не правильный email или пароль.");
            return new SignInResponse
            {
                IsSuccess = false,
                Errors = new[] { error },
            };
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

        return new SignInResponse
        {
            IsSuccess = true,
            Data = new SignInSuccessResponse
            {
                Id = domainUser.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Username = domainUser.Username,
            },
            Errors = null
        };
    }
}