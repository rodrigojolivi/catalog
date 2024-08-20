using FluentValidation;

namespace Catalog.Core.Application.Features.Users.ForgotPassword
{
    public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordCommand>
    {
        public ForgotPasswordValidator()
        {
                
        }
    }
}
