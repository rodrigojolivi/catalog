using FluentValidation;

namespace Catalog.Core.Application.Features.Users.ConfirmEmail
{
    public class ConfirmEmailValidator : AbstractValidator<ConfirmEmailCommand>
    {
        public ConfirmEmailValidator()
        {

        }
    }
}
