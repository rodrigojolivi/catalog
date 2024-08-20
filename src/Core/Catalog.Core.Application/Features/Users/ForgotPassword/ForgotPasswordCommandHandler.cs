using Catalog.Core.Application.Notifications;
using Catalog.Infrastructure.Identity.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Catalog.Core.Application.Features.Users.ForgotPassword
{
    public class ForgotPasswordCommandHandler : Response, IRequestHandler<ForgotPasswordCommand, Response>
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly IConfiguration _configuration;

        public ForgotPasswordCommandHandler(IIdentityRepository identityRepository, 
            IConfiguration configuration)
        {
            _identityRepository = identityRepository;
            _configuration = configuration;
        }

        public async Task<Response> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _identityRepository.ForgotPasswordAsync(request.Email);

            if (user == null)
            {
                AddNotification("Usuario não encontrado");

                return Failure();
            }

            var token = await _identityRepository.GeneratePasswordResetTokenAsync(user);

            return Success();
        }
    }
}
