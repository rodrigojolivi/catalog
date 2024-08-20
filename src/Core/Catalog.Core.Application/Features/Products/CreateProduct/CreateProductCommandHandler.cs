using Catalog.Core.Application.Notifications;
using Catalog.Core.Domain.Entities;
using Catalog.Core.Domain.Repositories;
using Catalog.Core.Domain.ValueObjects;
using MediatR;

namespace Catalog.Core.Application.Features.Products.CreateProduct
{
    public class CreateProductCommandHandler : Response, IRequestHandler<CreateProductCommand, Response>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Validate(new CreateProductValidator(), request);

            if (IsInvalid) return Failure();

            var product = new Product(request.Category, 
                request.Name, request.Price, new Stock(request.Quantity));

            _productRepository.Add(product);

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
