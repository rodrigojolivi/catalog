namespace Catalog.Infrastructure.Persistence.Extensions
{
    public static class PaginationExtension
    {
        public static async Task<IQueryable<TEntity>> ToPaginationAsync<TEntity>(this IQueryable<TEntity> query, int page, int size)
        {
            return await Task.Run(() => query.Skip((page - 1) * size).Take(size));
        }
    }
}
