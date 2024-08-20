using Catalog.Core.Application.Notifications;
using Catalog.Infrastructure.Identity.Interfaces;
using MediatR;

namespace Catalog.Core.Application.Features.Users.ResetPassword
{
    public class ResetPasswordCommandHandler : Response, IRequestHandler<ResetPasswordCommand, Response>
    {
        private readonly IIdentityRepository _identityRepository;

        public ResetPasswordCommandHandler(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public async Task<Response> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var identityResult = await _identityRepository.ResetPasswordAsync(
                request.Email, request.Token, request.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    AddNotification(error.Description);
                }

                return Failure();
            }

            return Success();
        }
    }
}
