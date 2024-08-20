using FluentValidation;

namespace Catalog.Core.Application.Features.Orders.GetOrdersByCustomer
{
    public class GetOrdersByCustomerValidator : AbstractValidator<GetOrdersByCustomerQuery>
    {
        public GetOrdersByCustomerValidator()
        {
            // TODO:
            // Validar os campos necessários
        }
    }
}
