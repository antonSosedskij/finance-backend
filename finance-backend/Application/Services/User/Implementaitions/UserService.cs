using finance_backend.Application.Identity.Contracts;
using finance_backend.Application.Identity.Interfaces;
using finance_backend.Application.Repositories;
using finance_backend.Application.Services.Category.Interfaces;
using finance_backend.Application.Services.User.Contracts;
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
    
    public async Task<Register.Response> Register(Register.Request request)
    {
        var response = await _identity.CreateUser(new CreateUser.Request
        {
            Username = request.Username,
            Email = request.Email,
            Password = request.Password,
        });

        if (response.IsSuccess)
        {
            var domainUser = new Domain.User
            {
                Id = response.Id,
                Username = request.Username,
                Name = request.Name,
                Lastname = request.Lastname,
                Email = request.Email,
                CreatedDate = DateTime.UtcNow,
            };
            
            await _repository.Save(domainUser);
            
            await _categoryService.CreateDefaultCategories(response.Id);

            return new Register.Response
            {
                Id = response.Id
            };
        }

        throw new Exception("wow, ne rabotaet!");
    }
}