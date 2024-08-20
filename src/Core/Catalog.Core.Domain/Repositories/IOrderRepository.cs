using Catalog.Core.Domain.Entities;

namespace Catalog.Core.Domain.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> FindOrderAsync(Guid idOrder);
        Task<IQueryable<Order>> GetOrdersAsync(int page, int size, string code);
        Task<IQueryable<Order>> GetOrdersByCustomerAsync(int page, int size, Guid idCustomer, string code);
    }
}
