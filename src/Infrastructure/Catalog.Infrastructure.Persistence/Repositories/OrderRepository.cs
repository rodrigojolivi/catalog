using Catalog.Core.Domain.Entities;
using Catalog.Core.Domain.Repositories;
using Catalog.Infrastructure.Persistence.Contexts;
using Catalog.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(CatalogContext context)
            : base(context)
        {

        }

        public async Task<Order> FindOrderAsync(Guid idOrder)
        {
            return await _dbSet.Where(x => x.Id == idOrder).Include(x => x.OrderItems).FirstOrDefaultAsync();
        }

        public async Task<IQueryable<Order>> GetOrdersAsync(int page, int size, string code)
        {
            var query = await Task.Run(() => _dbSet.AsNoTracking());

            if (!string.IsNullOrWhiteSpace(code))
            {
                query = query.Where(x => x.Code == code);
            }

            return await query.ToPaginationAsync(page, size);
        }

        public async Task<IQueryable<Order>> GetOrdersByCustomerAsync(int page, int size, Guid idCustomer, string code)
        {
            var query = await Task.Run(() => _dbSet.AsNoTracking().Where(x => x.IdCustomer == idCustomer));

            if (!string.IsNullOrWhiteSpace(code))
            {
                query = query.Where(x => x.Code == code);
            }

            return await query.ToPaginationAsync(page, size);
        }
    }
}
