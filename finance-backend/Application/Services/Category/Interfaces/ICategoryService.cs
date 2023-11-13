using finance_backend.Application.Services.Category.Contracts;

namespace finance_backend.Application.Services.Category.Interfaces;

public interface ICategoryService
{
    public Task<CreateCategory.Response> Create(CreateCategory.Request request);
}