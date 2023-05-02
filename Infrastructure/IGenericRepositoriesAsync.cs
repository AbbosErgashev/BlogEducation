using System.Linq.Expressions;

namespace BlogEducation.Infrastructure;

public interface IGenericRepositoryAsync<T> where T : class
{
    Task<T> GetByIdAsync(Expression<Func<T, bool>> expression, IList<string> includes);

    Task<IReadOnlyList<T>> GetAllAsync();

    Task<IReadOnlyList<T>> GetPagedAsyncList(int pageNumber, int pageSize);

    Task<T> AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}