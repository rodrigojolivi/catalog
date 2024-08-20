using Catalog.Core.Application.Notifications;
using Catalog.Infrastructure.Identity.Interfaces;
using Catalog.Infrastructure.Identity.Tokens;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Catalog.Core.Application.Features.Users.CreateUser
{
    public class CreateUserCommandHandler : Response, IRequestHandler<CreateUserCommand, Response>
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public CreateUserCommandHandler(IIdentityRepository identityRepository,
            ITokenService tokenService, IConfiguration configuration)
        {
            _identityRepository = identityRepository;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        public async Task<Response> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            Validate(new CreateUserValidator(), request);

            if (IsInvalid) return Failure();

            var identityResult = await _identityRepository.CreateUserAsync(
                request.Name, request.Email, request.Password, request.Role);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    AddNotification(error.Description);
                }

                return Failure();
            }

            var token = await _identityRepository.GeneratePasswordResetTokenAsync(request.Email);

            var response = token.ToResponse();

            return Success(response);
        }
    }
}
