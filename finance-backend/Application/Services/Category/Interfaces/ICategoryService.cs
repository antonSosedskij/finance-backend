using finance_backend.Application.Services.Category.Contracts;

namespace finance_backend.Application.Services.Category.Interfaces;

public interface ICategoryService
{
    public Task<CreateCategory.Response> Create(CreateCategory.Request request);

    public Task<GetCategory.Response> GetCategory(GetCategory.Request request);

    public Task<GetCategories.Response> GetCategories();
}