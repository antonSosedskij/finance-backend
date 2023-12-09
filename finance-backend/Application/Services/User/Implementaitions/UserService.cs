using finance_backend.Application.Identity.Contracts;
using finance_backend.Application.Identity.Interfaces;
using finance_backend.Application.Repositories;
using finance_backend.Application.Services.Category.Interfaces;
using finance_backend.Application.Services.User.Interfaces;

namespace finance_backend.Application.Services.User.Implementaitions;

public class UserService : IUserService
{
    
    private readonly IRepository<Domain.User, Guid> _repository;
    private readonly IIdentityService _identity;
    private readonly ICategoryService _categoryService;

    public UserService( 
        IRepository<Domain.User, Guid> repository,
        IIdentityService identity,
        ICategoryService categoryService)
    {
        _repository = repository;
        _identity = identity;
        _categoryService = categoryService;
    }

    public async Task<SignUpResponse> SignUp(SignUpRequest request)
    {
        var response = await _identity.SignUp(new SignUpRequest
        {
            Username = request.Username,
            Email = request.Email,
            Password = request.Password,
            Name = request.Name,
            Lastname = request.Lastname,
        });

        if (response.IsSuccess)
        {
            var domainUser = new Domain.User
            {
                Id = response.Data,
                Username = request.Username,
                Name = request.Name,
                Lastname = request.Lastname,
                Email = request.Email,
                CreatedDate = DateTime.UtcNow,
            };

            await _repository.Save(domainUser);

            await _categoryService.CreateDefaultCategories(response.Data);

            return new SignUpResponse
            {
                IsSuccess = true,
                Data = response.Data,
            };
        }

        return new SignUpResponse
        {
            IsSuccess = false,
            Errors = response.Errors.ToArray(),
        };
    }

    public async Task<SignInResponse> SignIn(SignInRequest request)
    {
        var response = await _identity.SignIn(new SignInRequest
        {
            Email = request.Email,
            Password = request.Password,
        });

        if (response.IsSuccess)
        {
            return new SignInResponse
            {
                IsSuccess = true,
                Data = new SignInSuccessResponse
                {
                    Token = response.Data.Token,
                    Id = response.Data.Id,
                    Username = response.Data.Username,
                },
            };
        }

        return new SignInResponse
        {
            IsSuccess = false,
            Errors = response.Errors.ToArray(),
        };
    }
}