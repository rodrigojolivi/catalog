using Catalog.Core.Domain.Entities;

namespace Catalog.Core.Application.Features.Orders.GetOrders
{
    public class GetOrdersResponse
    {
        public Guid IdOrder { get; set; }
        public DateTime Date { get; set; }
        public string Code { get; set; }
        public decimal Value { get; set; }
        public Guid IdCustomer { get; set; }
    }

    public static class Converter
    {
        public static IEnumerable<GetOrdersResponse> ToResponse(this IQueryable<Order> orders)
        {
            return orders.Select(x => new GetOrdersResponse
            {
                IdOrder = x.Id,
                Date = x.Date,
                Code = x.Code,
                Value = x.Value,
                IdCustomer = x.IdCustomer
            });
        }
    }
}
