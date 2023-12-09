using finance_backend.Application.Services.Category.Contracts;

namespace finance_backend.Application.Services.Category.Interfaces;

public interface ICategoryService
{
    public Task CreateDefaultCategories(Guid id);
    public Task<CreateCategory.Response> Create(CreateCategory.Request request);

    public Task<GetCategoryResponse> GetCategoryById(Guid id);

    public Task<GetCategories.Response> GetCategories();

    public Task DeleteCategory(DeleteCategory.Request request);
}