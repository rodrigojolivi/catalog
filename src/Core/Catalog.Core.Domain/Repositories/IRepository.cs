namespace Catalog.Core.Domain.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<IQueryable<TEntity>> GetAsync(int page, int size);
        Task<TEntity> FindAsync(Guid id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
