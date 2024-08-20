using Catalog.Core.Application.Notifications;
using MediatR;

namespace Catalog.Core.Application.Features.Orders.GetOrders
{
    public class GetOrdersQuery : IRequest<Response>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public string Code { get; set; }
    }
}
