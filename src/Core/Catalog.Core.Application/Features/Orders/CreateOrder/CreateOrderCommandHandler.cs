using Catalog.Core.Application.Notifications;
using Catalog.Core.Domain.Entities;
using Catalog.Core.Domain.Repositories;
using Catalog.Infrastructure.Identity.Interfaces;
using MediatR;

namespace Catalog.Core.Application.Features.Orders.CreateOrder
{
    public class CreateOrderCommandHandler : Response, IRequestHandler<CreateOrderCommand, Response>
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(IIdentityRepository identityRepository, IProductRepository productRepository,
            IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _identityRepository = identityRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Validate(new CreateOrderValidator(), request);

            if (IsInvalid) return Failure();

            var customer = await _identityRepository.FindUserByEmailAsync(request.EmailCustomer);

            if (customer == null)
            {
                AddNotification("Cliente não encontrado");

                return Failure();
            }

            var order = new Order(new Guid(customer.Id));

            foreach (var product in request.Products)
            {
                var existingProduct = await _productRepository.FindAsync(product.IdProduct);

                if (existingProduct == null)
                {
                    AddNotification($"O produto de id '{product.IdProduct}' não foi encontrado");

                    return Failure();
                }

                if (!existingProduct.HasStock(product.Quantity))
                {
                    AddNotification($"Não há estoque para o produto de id '{product.IdProduct}'");

                    return Failure();
                }

                existingProduct.RemoveStock(product.Quantity);

                _productRepository.Update(existingProduct);

                order.AddOrderItem(new OrderItem(existingProduct.Id, existingProduct.Name,
                    existingProduct.Price, product.Quantity, order.Id));

                order.SetValue(product.Quantity, existingProduct.Price);
            }

            _orderRepository.Add(order);

            var created = await _unitOfWork.CommitAsync();

            if (!created)
            {
                AddNotification("Erro ao criar o produto");

                return Failure();
            }

            return Success();
        }
    }
}
