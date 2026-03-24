using System.Linq.Expressions;

namespace MyBookCollection.Data.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task CreateAsync(TEntity entity);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);
    void Update(TEntity existingEntity, TEntity updatedEntity);
    void Delete(TEntity entity);
    Task<int> SaveAsync();
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);
}