using FluentValidation;

namespace Catalog.Core.Application.Features.Orders.DeleteOrder
{
    public class DeleteOrderValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderValidator()
        {
            // TODO:
            // Validar os campos necessários
        }
    }
}
