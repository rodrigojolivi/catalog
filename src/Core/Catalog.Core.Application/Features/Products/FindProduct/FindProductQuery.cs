using Catalog.Core.Application.Notifications;
using MediatR;

namespace Catalog.Core.Application.Features.Products.FindProduct
{
    public class FindProductQuery : IRequest<Response>
    {
        public Guid IdProduct { get; set; }
    }
}
