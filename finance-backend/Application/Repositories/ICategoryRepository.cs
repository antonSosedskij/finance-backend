using finance_backend.Domain;

namespace finance_backend.Application.Repositories;

public interface ICategoryRepository : IRepository<Category, Guid>
{
    public Task<IEnumerable<Category>> FindDefaultCategories(Guid userId);
}