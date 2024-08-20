using Catalog.Core.Application.Notifications;
using Catalog.Core.Domain.Repositories;
using MediatR;

namespace Catalog.Core.Application.Features.Orders.FindOrder
{
    public class FindOrderQueryHandler : Response, IRequestHandler<FindOrderQuery, Response>
    {
        private readonly IOrderRepository _productRepository;

        public FindOrderQueryHandler(IOrderRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Response> Handle(FindOrderQuery request, CancellationToken cancellationToken)
        {
            Validate(new FindOrderValidator(), request);

            if (IsInvalid) return Failure();

            var query = await _productRepository.FindOrderAsync(request.IdOrder);

            if (query == null)
            {
                AddNotification("Pedido não encontrado");

                return Failure();
            }

            var result = query.ToResponse();

            return Success(result);
        }
    }
}
