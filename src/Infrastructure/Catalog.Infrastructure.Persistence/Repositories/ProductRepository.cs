using Catalog.Core.Domain.Entities;
using Catalog.Core.Domain.Repositories;
using Catalog.Infrastructure.Persistence.Contexts;
using Catalog.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CatalogContext context)
            : base(context)
        {

        }

        public async Task<IQueryable<Product>> GetProductsAsync(int page, int size, string name)
        {
            var query = await Task.Run(() => _dbSet.AsNoTracking());

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(x => x.Name == name);
            }

            return await query.ToPaginationAsync(page, size);
        }
    }
}
