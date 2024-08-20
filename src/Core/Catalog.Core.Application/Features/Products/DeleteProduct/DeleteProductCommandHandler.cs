using Catalog.Core.Application.Notifications;
using Catalog.Core.Domain.Repositories;
using MediatR;

namespace Catalog.Core.Application.Features.Products.DeleteProduct
{
    public class DeleteProductCommandHandler : Response, IRequestHandler<DeleteProductCommand, Response>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Validate(new DeleteProductValidator(), request);

            if (IsInvalid) return Failure();

            var product = await _productRepository.FindAsync(request.IdProduct);

            if (product == null)
            {
                AddNotification("Produto não encontrado");

                return Failure();
            }

            _productRepository.Remove(product);

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
