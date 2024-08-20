using Catalog.Core.Application.Notifications;
using MediatR;

namespace Catalog.Core.Application.Features.Orders.GetOrdersByCustomer
{
    public class GetOrdersByCustomerQuery : IRequest<Response>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public Guid IdCustomer { get; set; }
        public string Code { get; set; }
    }
}
