using Catalog.Core.Application.Notifications;
using Catalog.Core.Domain.Repositories;
using MediatR;

namespace Catalog.Core.Application.Features.Orders.GetOrders
{
    public class GetOrdersQueryHandler : Response, IRequestHandler<GetOrdersQuery, Response>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Response> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            Validate(new GetOrdersValidator(), request);

            if (IsInvalid) return Failure();

            var query = await _orderRepository.GetOrdersAsync(request.Page, request.Size, request.Code);

            var result = query.ToResponse();

            return Success(result);
        }
    }
}
