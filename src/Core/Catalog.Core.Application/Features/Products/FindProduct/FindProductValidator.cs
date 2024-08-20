using FluentValidation;

namespace Catalog.Core.Application.Features.Products.FindProduct
{
    public class FindProductValidator : AbstractValidator<FindProductQuery>
    {
        public FindProductValidator()
        {
            // TODO:
            // Validar os campos necessários
        }
    }
}
