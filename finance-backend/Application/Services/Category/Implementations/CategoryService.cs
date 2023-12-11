using finance_backend.Application.Identity.Interfaces;
using finance_backend.Application.Repositories;
using finance_backend.Application.Services.Category.Contracts;
using finance_backend.Application.Services.Category.Interfaces;
using Newtonsoft.Json;
using static finance_backend.API.Dto.ErrorResponse;

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

    public async Task<GetCategoryResponse> GetCategoryById(Guid id)
    {
        var category = await _categoryRepository.FindById(id);

        if (category != null)
        {
            return new GetCategoryResponse
            {
                IsSuccess = false,
                Data = new Contracts.Category
                {
                    Id = category.Id,
                    Title = category.Title,
                    User = new Contracts.Category.Owner
                    {
                        Id = category.User.Id,
                        Username = category.User.Username,
                        Email = category.User.Email,
                        Name = category.User.Name,
                        Lastname = category.User.Lastname
                    }
                }
            };
        }

        var error = new ErrorItem("Категория не найдена.");
        return new GetCategoryResponse
        {
            IsSuccess = false,
            Errors = new[] { error }
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

    public async Task DeleteCategory(DeleteCategory.Request request)
    {
        var category = await _categoryRepository.FindById(request.Id);

        if (category == null)
        {
            throw new Exception("Категория не найдена");
        }

        await _categoryRepository.Delete(category);
    }

    public async Task CreateDefaultCategories(Guid userId)
    {
        using (var reader = new StreamReader("Infrastructure/DataAccess/Repository/DefaultCategories.json"))
        {
            var json = await reader.ReadToEndAsync();
            var defaultCategories = JsonConvert.DeserializeObject<List<Domain.Category>>(json);

            var newCategories = defaultCategories
                .Select((c, index) => new Domain.Category
                {
                    Id = Guid.NewGuid(),
                    Title = c.Title,
                    UserId = userId,
                    CreatedDate = DateTime.UtcNow
                })
                .ToList();

            if (newCategories.Any())
            {
                var firstCategory = newCategories.First();

                var defaultBalance = new Domain.Balance
                {
                    Id = Guid.NewGuid(),
                    Title = "Общий",
                    Percent = 100,
                    CategoryId = firstCategory.Id,
                    UserId = userId,
                    Expenses = new List<Domain.Expense>(),
                };

                firstCategory.Balances = new List<Domain.Balance> { defaultBalance };
            }

            await _categoryRepository.SaveAll(newCategories);
        }
    }

    public async Task<CreateCategory.Response> Create(CreateCategory.Request request)
    {
        var currentUserId = await _identityService.GetCurrentUserId();
        
        if (currentUserId == Guid.Empty)
        {
            throw new Exception("Вы не авторизованы");
        }
        
        var defaultCategories = await _categoryRepository.FindDefaultCategories(currentUserId);

        if (defaultCategories.Any(c => c.Title == request.Title))
        {
            throw new Exception("Такая категория уже существует");
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