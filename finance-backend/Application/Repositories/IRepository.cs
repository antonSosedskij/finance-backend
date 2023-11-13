using finance_backend.Domain.Shared;

namespace finance_backend.Application.Repositories;

public interface IRepository<TEntity, TId> where TEntity : BaseEntity<TId>
{
    Task Save(TEntity entity);
    
    Task<TEntity> FindById(TId id);
}