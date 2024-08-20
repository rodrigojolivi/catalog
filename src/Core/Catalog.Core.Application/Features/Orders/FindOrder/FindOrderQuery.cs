using Catalog.Core.Application.Notifications;
using MediatR;

namespace Catalog.Core.Application.Features.Orders.FindOrder
{
    public class FindOrderQuery : IRequest<Response>
    {
        public Guid IdOrder { get; set; }
    }
}
