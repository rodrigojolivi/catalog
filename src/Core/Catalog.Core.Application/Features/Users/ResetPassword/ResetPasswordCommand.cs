using MediatR;
using Catalog.Core.Application.Notifications;

namespace Catalog.Core.Application.Features.Users.ResetPassword
{
    public class ResetPasswordCommand : IRequest<Response>
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
    }
}
