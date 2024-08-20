using Catalog.Core.Application.Notifications;
using MediatR;

namespace Catalog.Core.Application.Features.Orders.CreateOrder
{
    public class CreateOrderCommand : IRequest<Response>
    {
        public string EmailCustomer { get; set; }
        public IList<ProductCommand> Products { get; set; }

        public class ProductCommand
        {
            public Guid IdProduct { get; set; }
            public int Quantity { get; set; }
        }
    }
}
