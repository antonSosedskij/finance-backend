using finance_backend.Application.Repositories;
using finance_backend.DataAccess.Models;
using finance_backend.Domain;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace finance_backend.Infrastructure.Data_access.Repository;

public class CategoryRepository : Repository<Category, Guid>, ICategoryRepository
{
    public CategoryRepository(ApplicationContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<Category>> FindDefaultCategories(Guid userId)
    {
        var userCategories = await _context.categories
            .Where(c => c.UserId == userId)
            .ToListAsync();
        
        var filteredCategories = userCategories
            .Where(c => IsTitleInDefaultCategories(c.Title))
            .ToList();

        return filteredCategories;
    }
    
    private bool IsTitleInDefaultCategories(string title)
    {
        using (var reader = new StreamReader("Infrastructure/Data-access/Repository/DefaultCategories.json"))
        {
            var json = reader.ReadToEnd();
            var defaultCategories = JsonConvert.DeserializeObject<List<Category>>(json);
            
            var defaultTitles = defaultCategories.Select(dc => dc.Title).ToList();
            
            var isTitleInDefaultCategories = defaultTitles.Contains(title);

            return isTitleInDefaultCategories;
        }
    }
}