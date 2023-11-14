using finance_backend.Application.Identity.Interfaces;
using finance_backend.Application.Repositories;
using finance_backend.Application.Services.Category.Contracts;
using finance_backend.Application.Services.Category.Interfaces;

namespace finance_backend.Application.Services.Category.Implementations;

public class CategoryService : ICategoryService
{
    private IIdentityService _identityService;
    private ICategoryRepository _categoryRepository;

    public CategoryService(
        IIdentityService identityService,
        ICategoryRepository categoryRepository)
    {
        _identityService = identityService;
        _categoryRepository = categoryRepository;
    }

    public async Task<GetCategory.Response> GetCategory(GetCategory.Request request)
    {
        var category = await _categoryRepository.FindById(request.Id);

        return new GetCategory.Response
        {
            Id = category.Id,
            Title = category.Title,
            User = new GetCategory.Response.Owner
            {
                Id = category.User.Id,
                Username = category.User.Username,
                Email = category.User.Email,
                Name = category.User.Name,
                Lastname = category.User.Lastname
            }
        };
    }

    public async Task<GetCategories.Response> GetCategories()
    {
        var categoriesList = await _categoryRepository.FindAll();

        if (categoriesList == null)
        {
            throw new Exception("Категории не найдены");
        }

        return new GetCategories.Response
        {
            Categories = categoriesList.Select(a => new GetCategories.Response.Item
            {
                Id = a.Id,
                Title = a.Title
            })
        };
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
            CreatedDate = DateTime.UtcNow
        };

        await _categoryRepository.Save(category);

        return new CreateCategory.Response
        {
            Id = category.Id,
            Title = category.Title,
            UserId = category.UserId
        };
    }
}