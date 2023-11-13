using finance_backend.Application.Identity.Interfaces;
using finance_backend.Application.Services.Category.Contracts;
using finance_backend.Application.Services.Category.Interfaces;
using finance_backend.Domain;

namespace finance_backend.Application.Services.Category.Implementations;

public class CategoryService : ICategoryService
{
    private IIdentityService _identityService;

    public CategoryService(
        IIdentityService identityService)
    {
        _identityService = identityService;
    }
    
    public async Task<CreateCategory.Response> Create(CreateCategory.Request request)
    {
        var currentUserId = await _identityService.GetCurrentUserId();

        if (currentUserId == Guid.Empty)
        {
            throw new Exception("Вы не авторизованы");
        }

        var category = new Domain.Category
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            UserId = currentUserId,
        };

        return new CreateCategory.Response
        {
            Id = category.Id,
            Title = category.Title,
            UserId = category.UserId
        };
    }
}