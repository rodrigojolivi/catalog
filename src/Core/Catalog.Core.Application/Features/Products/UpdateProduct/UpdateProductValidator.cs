using FluentValidation;

namespace Catalog.Core.Application.Features.Products.UpdateProduct
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            // TODO:
            // Validar os campos necessários
        }
    }
}
