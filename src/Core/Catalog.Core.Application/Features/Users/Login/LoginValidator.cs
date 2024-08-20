using FluentValidation;

namespace Catalog.Core.Application.Features.Users.Login
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {
        public LoginValidator()
        {
                
        }
    }
}
