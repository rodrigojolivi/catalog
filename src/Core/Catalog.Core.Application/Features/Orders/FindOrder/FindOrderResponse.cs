using Catalog.Core.Domain.Entities;

namespace Catalog.Core.Application.Features.Orders.FindOrder
{
    public class FindOrderResponse
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid IdOrder { get; set; }
        public DateTime Date { get; set; }
        public string Code { get; set; }
        public decimal Value { get; set; }
        public Guid IdCustomer { get; set; }
        public IList<OrderItemQuery> OrderItems { get; set; }

        public class OrderItemQuery
        {
            public Guid IdProduct { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public decimal Total { get; set; }
            public Guid IdOrder { get; set; }
        }
    }

    public static class Converter
    {
        public static FindOrderResponse ToResponse(this Order order)
        {
            return new FindOrderResponse
            {
                CreatedAt = order.CreatedAt,
                UpdatedAt = order.UpdatedAt,
                IdOrder = order.Id,
                Date = order.Date,
                Code = order.Code,
                Value = order.Value,
                IdCustomer = order.IdCustomer,

                OrderItems = order.OrderItems.Select(x => new FindOrderResponse.OrderItemQuery
                {
                    IdProduct = x.IdProduct,
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    Total = x.Total,
                    IdOrder = x.IdOrder

                }).ToList()
            };
        }
    }
}
