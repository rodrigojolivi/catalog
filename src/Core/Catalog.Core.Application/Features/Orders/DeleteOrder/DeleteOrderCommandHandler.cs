using Catalog.Core.Application.Notifications;
using Catalog.Core.Domain.Repositories;
using MediatR;

namespace Catalog.Core.Application.Features.Orders.DeleteOrder
{
    public class DeleteOrderCommandHandler : Response, IRequestHandler<DeleteOrderCommand, Response>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            Validate(new DeleteOrderValidator(), request);

            if (IsInvalid) return Failure();

            var order = await _orderRepository.FindAsync(request.IdOrder);

            if (order == null)
            {
                AddNotification("Produto não encontrado");

                return Failure();
            }

            _orderRepository.Remove(order);

            var created = await _unitOfWork.CommitAsync();

            if (!created)
            {
                AddNotification("Erro ao excluir o produto");

                return Failure();
            }

            return Success();
        }
    }
}
