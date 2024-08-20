using Catalog.Core.Application.Notifications;
using Catalog.Core.Domain.Repositories;
using MediatR;

namespace Catalog.Core.Application.Features.Stocks.CreateStock
{
    public class CreateStockCommandHandler : Response, IRequestHandler<CreateStockCommand, Response>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStockCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(CreateStockCommand request, CancellationToken cancellationToken)
        {
            Validate(new CreateStockValidator(), request);

            if (IsInvalid) return Failure();

            var product = await _productRepository.FindAsync(request.IdProduct);

            if (product == null)
            {
                AddNotification("Produto não encontrado");

                return Failure();
            }

            product.AddStock(request.Quantity);

            _productRepository.Update(product);

            var created = await _unitOfWork.CommitAsync();

            if (!created)
            {
                AddNotification("Erro ao criar estoque");

                return Failure();
            }

            return Success();
        }
    }
}
