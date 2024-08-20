using MediatR;
using Catalog.Core.Application.Notifications;

namespace Catalog.Core.Application.Features.Users.Login
{
    public class LoginCommand : IRequest<Response>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
