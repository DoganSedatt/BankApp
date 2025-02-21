using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Paging;

public static class IQueryablePaginateExtensions
{
    public static async Task<IPaginate<T>> ToPaginateAsync<T>(
        this IQueryable<T> source,
        int index,
        int size,
        CancellationToken cancellationToken = default)
    {
        int count = await source.CountAsync(cancellationToken);
        List<T> items = await source.Skip(index * size).Take(size).ToListAsync(cancellationToken);
        
        return new Paginate<T>
        {
            Index = index,
            Size = size,
            Count = count,
            Items = items,
            Pages = (int)Math.Ceiling(count / (double)size)
        };
    }
} 