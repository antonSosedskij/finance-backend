using finance_backend.Application.Repositories;
using finance_backend.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace finance_backend.DataAccess.Models.Data_access.Repository;

public class Repository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
{
    protected readonly ApplicationContext _context;
    
    public Repository(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task Save(TEntity entity)
    {
        var entry = _context.Entry(entity);

        if (entry.State == EntityState.Detached)
        {
            await _context.AddAsync(entity);
        }
        await _context.SaveChangesAsync();
    }
    
    public async Task<TEntity> FindById(TId id)
    {
        return await _context.FindAsync<TEntity>(new object[] {id});
    }
}