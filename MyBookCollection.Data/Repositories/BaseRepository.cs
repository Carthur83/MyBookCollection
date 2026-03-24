using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyBookCollection.Data.Contexts;
using MyBookCollection.Data.Interfaces;
using System.Diagnostics;
using System.Linq.Expressions;

namespace MyBookCollection.Data.Repositories;

public abstract class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class
{
    private readonly DataContext _context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public virtual async Task CreateAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(expression);
        return entity;
    }

    public virtual void Update(TEntity existingEntity, TEntity updatedEntity)
    {
        _dbSet.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
    }

    public virtual void Delete(TEntity entity)
    {
        _context.Remove(entity);
    }

    public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbSet.AnyAsync(expression);
    }

    public virtual async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}

