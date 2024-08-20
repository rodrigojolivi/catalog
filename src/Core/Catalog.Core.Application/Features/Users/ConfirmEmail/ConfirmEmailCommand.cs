using MediatR;
using Catalog.Core.Application.Notifications;

namespace Catalog.Core.Application.Features.Users.ConfirmEmail
{
    public class ConfirmEmailCommand : IRequest<Response>
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
