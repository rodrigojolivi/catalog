using MediatR;
using Catalog.Core.Application.Notifications;

namespace Catalog.Core.Application.Features.Users.ForgotPassword
{
    public class ForgotPasswordCommand : IRequest<Response>
    {
        public string Email { get; set; }
    }
}
