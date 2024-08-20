using Catalog.Core.Application.Notifications;
using Catalog.Core.Domain.Repositories;
using MediatR;

namespace Catalog.Core.Application.Features.Products.FindProduct
{
    public class FindProductQueryHandler : Response, IRequestHandler<FindProductQuery, Response>
    {
        private readonly IProductRepository _productRepository;

        public FindProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Response> Handle(FindProductQuery request, CancellationToken cancellationToken)
        {
            Validate(new FindProductValidator(), request);

            if (IsInvalid) return Failure();

            var query = await _productRepository.FindAsync(request.IdProduct);

            if (query == null)
            {
                AddNotification("Produto não encontrado");

                return Failure();
            }

            var result = query.ToResponse();

            return Success(result);
        }
    }
}
