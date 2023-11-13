using finance_backend.Application.Repositories;
using finance_backend.DataAccess.Models;
using finance_backend.Domain;

namespace finance_backend.Infrastructure.Data_access.Repository;

public class CategoryRepository : Repository<Category, Guid>, ICategoryRepository
{
    public CategoryRepository(ApplicationContext context) : base(context)
    {
        
    }
}