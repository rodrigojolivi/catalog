using Catalog.Core.Application.Notifications;
using MediatR;

namespace Catalog.Core.Application.Features.Products.GetProducts
{
    public class GetProductsQuery : IRequest<Response>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public string Name { get; set; }
    }
}
