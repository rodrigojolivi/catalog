using Catalog.Core.Application.Notifications;
using Catalog.Core.Domain.Enums;
using MediatR;

namespace Catalog.Core.Application.Features.Products.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Response>
    {
        public Guid IdProduct { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
