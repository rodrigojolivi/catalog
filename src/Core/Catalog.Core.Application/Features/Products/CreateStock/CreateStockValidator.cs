using FluentValidation;

namespace Catalog.Core.Application.Features.Stocks.CreateStock
{
    public class CreateStockValidator : AbstractValidator<CreateStockCommand>
    {
        public CreateStockValidator()
        {
            // TODO:
            // Validar os campos necessários
        }
    }
}
