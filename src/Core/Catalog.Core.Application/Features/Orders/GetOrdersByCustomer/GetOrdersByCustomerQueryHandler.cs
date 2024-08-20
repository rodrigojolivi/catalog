using Catalog.Core.Application.Notifications;
using Catalog.Core.Domain.Repositories;
using MediatR;

namespace Catalog.Core.Application.Features.Orders.GetOrdersByCustomer
{
    public class GetOrdersByCustomerQueryHandler : Response, IRequestHandler<GetOrdersByCustomerQuery, Response>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersByCustomerQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Response> Handle(GetOrdersByCustomerQuery request, CancellationToken cancellationToken)
        {
            Validate(new GetOrdersByCustomerValidator(), request);

            if (IsInvalid) return Failure();

            var query = await _orderRepository.GetOrdersByCustomerAsync(
                request.Page, request.Size, request.IdCustomer, request.Code);

            var result = query.ToResponse();

            return Success(result);
        }
    }
}
