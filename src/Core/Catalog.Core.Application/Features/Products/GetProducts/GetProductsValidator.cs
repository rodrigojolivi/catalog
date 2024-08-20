using FluentValidation;

namespace Catalog.Core.Application.Features.Products.GetProducts
{
    public class GetProductsValidator : AbstractValidator<GetProductsQuery>
    {
        public GetProductsValidator()
        {
            // TODO:
            // Validar os campos necessários
        }
    }
}
