using FluentValidation;

namespace Catalog.Core.Application.Features.Orders.FindOrder
{
    public class FindOrderValidator : AbstractValidator<FindOrderQuery>
    {
        public FindOrderValidator()
        {
            // TODO:
            // Validar os campos necessários
        }
    }
}
