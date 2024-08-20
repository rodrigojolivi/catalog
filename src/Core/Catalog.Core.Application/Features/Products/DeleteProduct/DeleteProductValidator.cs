using FluentValidation;

namespace Catalog.Core.Application.Features.Products.DeleteProduct
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidator()
        {
            // TODO:
            // Validar os campos necessários
        }
    }
}
