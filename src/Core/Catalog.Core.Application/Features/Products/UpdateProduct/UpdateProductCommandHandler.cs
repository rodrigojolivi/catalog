using Catalog.Core.Application.Notifications;
using Catalog.Core.Domain.Repositories;
using MediatR;

namespace Catalog.Core.Application.Features.Products.UpdateProduct
{
    public class UpdateProductCommandHandler : Response, IRequestHandler<UpdateProductCommand, Response>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Validate(new UpdateProductValidator(), request);

            if (IsInvalid) return Failure();

            var product = await _productRepository.FindAsync(request.IdProduct);

            if (product == null)
            {
                AddNotification("Produto não encontrado");

                return Failure();
            }

            product.Update(request.Category, request.Name, request.Value);

            _productRepository.Update(product);

            var updated = await _unitOfWork.CommitAsync();

            if (!updated)
            {
                AddNotification("Erro ao atualizar o produto");

                return Failure();
            }

            return Success();
        }
    }
}
