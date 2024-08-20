using Catalog.Core.Application.Notifications;
using Catalog.Core.Domain.Repositories;
using MediatR;

namespace Catalog.Core.Application.Features.Products.GetProducts
{
    public class GetProductsQueryHandler : Response, IRequestHandler<GetProductsQuery, Response>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Response> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            Validate(new GetProductsValidator(), request);

            if (IsInvalid) return Failure();

            var query = await _productRepository.GetProductsAsync(request.Page, request.Size, request.Name);

            var result = query.ToResponse();

            return Success(result);
        }
    }
}
