using Catalog.Core.Application.Notifications;
using Catalog.Infrastructure.Identity.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Catalog.Core.Application.Features.Users.FindUser
{
    public class FindUserQueryHandler : Response, IRequestHandler<FindUserQuery, Response>
    {
        private readonly IIdentityRepository _identityRepository;

        public FindUserQueryHandler(IIdentityRepository identityRepository, 
            IHttpContextAccessor httpContextAccessor)
            : base(httpContextAccessor)
        {
            _identityRepository = identityRepository;
        }

        public async Task<Response> Handle(FindUserQuery request, CancellationToken cancellationToken)
        {
            Validate(new FindUserValidator(), request);

            if (IsInvalid) return Failure();

            var user = await _identityRepository.FindUserByEmailAsync(email);

            if (request.IdUser != null)
            {
                user = await _identityRepository.FindUserByIdAsync(request.IdUser.Value);
            }

            if (user == null)
            {
                AddNotification("Usuário não encontrado");

                return Failure();
            }

            var response = user.ToResponse();

            return Success(response);
        }
    }
}
