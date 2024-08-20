using FluentValidation;

namespace Catalog.Core.Application.Features.Orders.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            // TODO:
            // Validar os campos necessários
        }
    }
}
