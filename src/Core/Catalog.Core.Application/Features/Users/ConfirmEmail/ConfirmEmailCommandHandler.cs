using Catalog.Core.Application.Notifications;
using Catalog.Infrastructure.Identity.Interfaces;
using MediatR;

namespace Catalog.Core.Application.Features.Users.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : Response, IRequestHandler<ConfirmEmailCommand, Response>
    {
        private readonly IIdentityRepository _identityRepository;

        public ConfirmEmailCommandHandler(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public async Task<Response> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var emailConfirmed = await _identityRepository.ConfirmEmailAsync(request.Email, request.Token);

            if (!emailConfirmed)
            {
                AddNotification("Ocorreu um erro ao confirmar o email do usuário");

                return Failure();
            }

            return Success();
        }
    }
}
