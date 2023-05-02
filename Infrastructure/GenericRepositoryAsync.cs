using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogEducation.Infrastructure;

public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
{
    private readonly ApplicationDbContext _dbContext;

    public GenericRepositoryAsync(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);

        await _dbContext.SaveChangesAsync();

        return entity;
    }
    
    public virtual async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);

        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public virtual async Task<T> GetByIdAsync(Expression<Func<T, bool>> expression, IList<string> includes)
    {
        IQueryable<T> entity = _dbContext.Set<T>();

        foreach(var include in includes)
        {
            entity = entity.Include(include);
        }

        return await entity.FirstOrDefaultAsync(expression);
    }

    public virtual async Task<IReadOnlyList<T>> GetPagedAsyncList(int pageNumber, int pageSize)
    {
        return await _dbContext.Set<T>()
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTracking()
        .ToListAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;

        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> SaveChangesAysnc()
    {
        return await _dbContext.SaveChangesAsync() >= 0;
    }
}