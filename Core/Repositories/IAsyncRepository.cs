using System.Linq.Expressions;
using Core.Paging;
using Microsoft.EntityFrameworkCore.Query;

public interface IAsyncRepository<T> where T : class
{
    // Get operations
    Task<T?> GetAsync(
        Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    // List operations with pagination
    Task<IPaginate<T>> GetListAsync(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        int index = 0,
        int size = 10,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    // Any operation
    Task<bool> AnyAsync(
        Expression<Func<T, bool>>? predicate = null,
        CancellationToken cancellationToken = default
    );

    // Add operations
    Task<T> AddAsync(T entity);
    Task<ICollection<T>> AddRangeAsync(ICollection<T> entities);

    // Update operations
    Task<T> UpdateAsync(T entity);
    Task<ICollection<T>> UpdateRangeAsync(ICollection<T> entities);

    // Delete operations
    Task<T> DeleteAsync(T entity);
    Task<ICollection<T>> DeleteRangeAsync(ICollection<T> entities);
} 