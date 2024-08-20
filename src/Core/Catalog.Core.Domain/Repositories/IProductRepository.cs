using Catalog.Core.Domain.Entities;

namespace Catalog.Core.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IQueryable<Product>> GetProductsAsync(int page, int size, string name);
    }
}
