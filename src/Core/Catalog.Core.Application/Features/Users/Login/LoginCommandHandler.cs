using Catalog.Core.Application.Notifications;
using Catalog.Infrastructure.Identity.Interfaces;
using Catalog.Infrastructure.Identity.Tokens;
using MediatR;

namespace Catalog.Core.Application.Features.Users.Login
{
    public class LoginCommandHandler : Response, IRequestHandler<LoginCommand, Response>
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(IIdentityRepository identityRepository, ITokenService tokenService)
        {
            _identityRepository = identityRepository;
            _tokenService = tokenService;
        }

        public async Task<Response> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _identityRepository.LoginAsync(request.Email, request.Password);

            if (user == null)
            {
                AddNotification("Usuario e/ou senha inválido(s)");

                return Failure();
            }

            var roles = await _identityRepository.GetRolesAsync(user);   

            var accessToken = _tokenService.GenerateToken(user.Name, user.Email, roles);

            var response = new LoginResponse
            {
                AccessToken = accessToken,
                Name = user.Name,
                Email = user.Email,
                Roles = roles
            };

            return Success(response);
        }
    }
}
