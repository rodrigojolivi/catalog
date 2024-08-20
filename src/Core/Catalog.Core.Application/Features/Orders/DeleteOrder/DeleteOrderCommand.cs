using Catalog.Core.Application.Notifications;
using Catalog.Core.Domain.Enums;
using MediatR;

namespace Catalog.Core.Application.Features.Orders.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<Response>
    {
        public Guid IdOrder { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
